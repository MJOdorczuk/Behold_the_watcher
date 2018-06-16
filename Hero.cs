using System;
using System.Collections.Generic;
using System.Text;

namespace Behold_the_watcher
{
    class Hero : Actor
    {

        private int strength;
        private int agility;
        private int hp;
        private readonly String name;
        private int face;
        public static int BASICHP = 5;

        public Hero(List<Item> equipment, int strength, int agility, String name) : base(equipment)
        {
            this.strength = strength;
            this.agility = agility;
            this.name = name;
            face = Direction.FORWARD;
            hp = BASICHP;
        }
        public override String Examine()
        {
            String be1 = " was ";
            String be3 = " was ";
            if (IsAlive()) { be1 = " am "; be3 = " is "; }
            String ret = "I" + name + ".\n";
            ret += "I" + be1 + "the hero you needed.\n";
            ret += "My strength" + be3 + strength.ToString() + ".\n";
            ret += "My agility" + be3 + agility.ToString() + ".\n";
            if (IsAlive())
                ret += "I am still alive with " + hp.ToString() + " hit points to loose.";
            else ret += "I am dead as I died because of you.";
            return ret;
        }
        public void Damage(int damage) => this.hp -= damage;
        public void Equip(Item item) => equipment.Add(item);
        public void Turn(int direction)
        {
            this.face = Direction.Turn(GetOrientation(), direction);
        }
        public int GetOrientation() => (int)this.face;
        public bool IsAlive() => hp > 0;
        public Room GoForward(Room location)
        {
            Door door = location.GoTo(GetOrientation());
            if (face == 4 || face == 5)
                face = 0;
            if (door == null)
                return null;
            else
            {
                foreach (Item item in equipment)
                {
                    door.Unlock(item);
                }
                return door.GoThrough(location);
            }
        }
        public override string Name() => name;
        public int GetStrength() => strength;
        public int GetAgility() => agility;
        internal string Bagpack()
        {
            if (equipment.Count == 0)
                return "My sac was empty.\n";
            else
            {
                string ret = "In the pouch I had:\n";
                foreach (Item item in equipment)
                {
                    ret += " - one " + item.Name() + "\n";
                }
                return ret;
            }
        }
        public void Reborn()
        {
            face = Direction.FORWARD;
            hp = BASICHP;
            equipment.RemoveAll(x => true);
        }
    }
}
