using System;
using System.Collections.Generic;
using System.Text;

namespace Behold_the_watcher
{
    abstract class Item : Actor
    {
        public Item(List<Item> equipment) : base(equipment)
        {
        }

        public override Item BeEquiped() => this;
    }
}
