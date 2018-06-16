using System;
using System.Collections.Generic;
using System.Text;

namespace Behold_the_watcher
{
    class Door
    {
        private readonly Room inside, outside;
        private bool locked;
        private readonly Key key;

        public Door(Room inside, Room outside, Key key, int direction)
        {
            this.inside = inside;
            this.outside = outside;
            this.key = key;
            if (key == null)
                locked = false;
            else locked = true;
            inside.SetDoor(this, direction);
            outside.SetDoor(this, Direction.Reverse(direction));
        }
        public Room GoThrough(Room from)
        {
            if (locked || (from != inside && from != outside))
                return null;
            else if (from == outside)
                return inside;
            else return outside;
        }
        public bool Unlock(Item key)
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
