using System;
using System.Collections.Generic;
using System.Text;

namespace Behold_the_watcher
{
    class Ezgara : Creature
    {
        private bool stolen;

        public Ezgara(List<Item> equipment, int ad, int hp) : base(equipment, ad, hp)
        {
            stolen = false;
        }

        public override string Examine()
        {
            return "The decadent emperor of Letheras or two-headed bug.";
        }

        public override string Name()
        {
            return "Ezgara";
        }

        internal override string MakeAction(Hero wanderer, Room hall)
        {
            Random rand = new Random();
            int risk = wanderer.GetAgility() - ad;
            if(risk > 0 && !stolen)
            {
                if(rand.Next(risk) < risk/2)
                {
                    return "Ezgara tried to reach me, but I managed to escape him.\n";
                }
            }
            List<Item> eq = wanderer.GetLoot();
            if(eq.Count == 0 || stolen)
            {
                if(Run(hall))
                {
                    return "Ezgara just flew from that room.\n";
                }
                return "Ezgara started to run over that chamber.\n";
            }
            else
            {
                int index = rand.Next(eq.Count - 1);
                Item loot = eq[index];
                equipment.Add(loot);
                eq.RemoveAt(index);
                stolen = true;
                return "Ezgara stole one " + loot.Name() + " from me.\n";
            }
        }

        private bool Run(Room hall)
        {
            bool escaped = false;
            int shift = Direction.RandomDirection;
            int tries = new Random().Next(6);
            Door way_out;
            Room next;
            for(int i = 0; i < tries; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    way_out = hall.GoTo((j + shift) % 6);
                    if (way_out == null) next = null;
                    else next = way_out.GoThrough(hall);
                    if (next == null) return escaped;
                    else
                    {
                        hall.GetDwellers().Remove(this);
                        hall = next;
                        hall.GetDwellers().Add(this);
                        escaped = true;
                    }
                }
            }
            return escaped;
        }
    }
}
