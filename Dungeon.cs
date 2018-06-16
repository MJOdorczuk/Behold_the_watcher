using System;
using System.Collections.Generic;
using System.Text;

namespace Behold_the_watcher
{
    // The model    
    class Dungeon
    {
        private Room hall;
        private Hero wanderer;
        private readonly Func<Room> generator;
        public Dungeon(Func<Room> generator, Hero wanderer)
        {
            this.generator = generator;
            hall = generator();
            this.wanderer = wanderer;
        }
        public Room GetHall() => hall;
        public Hero GetWanderer() => wanderer;
        internal string Go(int direction)
        {
            string ret = "";
            wanderer.Turn(direction);
            Room nextRoom = wanderer.GoForward(hall);
            if(nextRoom == null)
            {
                ret += "Door is locked.\n";
            }
            else
            {
                ret += "You cross the door to the next room.\n";
                hall = nextRoom;
            }
            return ret;
        }
        internal string Examine(int index)
        {
            if (index >= 0 && index < hall.GetStaticActors().Count)
            {
                Actor examined = hall.GetStaticActors()[index];
                List<Item> loot = examined.GetLoot();
                string ret = hall.GetStaticActors()[index].Examine();
                foreach (Item item in loot)
                {
                    hall.AddStaticActor(item);
                }
                loot.RemoveAll(item => true);
                return ret;
            }
            else
                return "There was nothing like this in the room.\n";
        }
        internal string ExamineThisHall()
        {
            return hall.Examine(wanderer.GetOrientation());
        }
        internal string Take(int index)
        {
            if(index < 0 || index >= hall.GetStaticActors().Count)
            {
                return "There was no item like this.\n";
            }
            else
            {
                Actor actor = hall.GetStaticActors()[index];
                Item item = actor.BeEquiped();
                if(item == null)
                {
                    return "It couldn't be taken.\n";
                }
                else
                {
                    wanderer.Equip(item);
                    hall.GetStaticActors().RemoveAt(index);
                    return item.Name() + " taken.\n";
                }
            }
        }
        internal string Hit(int index)
        {
            if(index < 0 || index >= hall.GetDwellers().Count)
            {
                return "I hit the air.\n";
            }
            else
            {
                Creature creature = hall.GetDwellers()[index];
                creature.Damage(wanderer.GetStrength());
                if(creature.IsAlive())
                {
                    return "I hit the " + creature.Name() + " with " + wanderer.GetStrength() + " damage.\n";
                }
                else
                {
                    List<Item> loot = creature.GetLoot();
                    hall.GetDwellers().Remove(creature);
                    hall.GetStaticActors().AddRange(loot);
                    return "I killed the " + creature.Name() + ".\n";
                }
            }
        }
        internal string MakeTurn()
        {
            string ret = "";
            foreach(Creature dweller in hall.GetDwellers().FindAll(x => true))
            {
                ret += dweller.MakeAction(wanderer, hall);
            }
            return ret;
        }
        public void Rebuild()
        {
            hall = generator();
            wanderer.Reborn();
        }
    }
}
