using System;
using System.Collections.Generic;
using System.Text;

namespace Behold_the_watcher
{
    abstract class Actor
    {
        protected List<Item> equipment;
        public Actor(List<Item> equipment) => this.equipment = equipment;
        public abstract String Examine();
        public abstract String Name();

        public virtual Item BeEquiped() => null;

        public virtual List<Item> GetLoot() => equipment;
    }
}
