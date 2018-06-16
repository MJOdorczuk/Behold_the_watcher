using System;
using System.Collections.Generic;
using System.Text;

namespace Behold_the_watcher
{
    class Gulden : Item
    {
        public Gulden() : base(new List<Item>()) { }

        public override string Examine()
        {
            return "It is an old valuable coin worth enough to purchase either a horse, a house or a small sack of pepper.\n";
        }

        public override string Name()
        {
            return "old, valuable coin";
        }
    }
}
