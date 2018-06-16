using System;
using System.Collections.Generic;
using System.Text;

namespace Behold_the_watcher
{
    class Locker : Actor
    {
        private readonly Key key;
        private bool locked;
        public Locker(List<Item> equipment, Key key) : base(equipment)
        {
            this.key = key;
            if (key == null)
                locked = false;
            else locked = true;
        }

        public override string Examine()
        {
            if (locked)
                return "The " + Name() + " was locked.\n";
            else if (equipment.Count == 0)
                return "The " + Name() + " was empty.\n";
            else
            {
                string ret = "There were few things inside.\n";
                foreach(Item item in equipment)
                {
                    ret += "I got one " + item.Name() + "\n";
                }
                return ret;
            }
        }

        public override List<Item> GetLoot()
        {
            if(locked)
            {
                return new List<Item>();
            }
            else return base.GetLoot();
        }

        public override string Name()
        {
            return "old locker";
        }
        public bool Unlock(Key key)
        {
            if (locked)
            {
                if (this.key == key)
                {
                    this.locked = false;
                    return true;
                }
                else return false;
            }
            else return true;
        }
    }
}
