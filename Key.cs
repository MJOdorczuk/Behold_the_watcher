using System;
using System.Collections.Generic;
using System.Text;

namespace Behold_the_watcher
{
    class Key : Item
    {
        public Key() : base(new List<Item>()) { }

        public override string Examine()
        {
            return "It is some rusty, old key. Maybe it can open some door or locker here.\n";
        }

        public override string Name()
        {
            return "old key";
        }
    }
}
