using System;
using System.Collections.Generic;
using System.Text;

namespace Behold_the_watcher
{
    class Painting : Actor
    {
        public Painting(List<Item> equipment) : base(equipment)
        {
        }

        public override string Examine()
        {
            
            if (equipment.Count == 0)
                return "It was one beautiful " + Name() + ".\n";
            else
            {
                string ret = "There were few things behind the canvas.\n";
                foreach (Item item in equipment)
                {
                    ret += "I got one " + item.Name() + "\n";
                }
                return ret;
            }
        }

        public override string Name()
        {
            return "old painting from the Old Empire's age";
        }
    }
}
