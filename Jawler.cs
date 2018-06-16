using System;
using System.Collections.Generic;
using System.Text;

namespace Behold_the_watcher
{
    class Jawler : Creature
    {
        public Jawler(List<Item> equipment, int ad, int hp) : base(equipment, ad, hp)
        {
        }

        public override string Examine()
        {
            return "If you thought that you have seen big jaws, that were big jaws.\n";
        }

        public override string Name()
        {
            return "Jawler";
        }

        internal override string MakeAction(Hero wanderer, Room hall)
        {
            wanderer.Damage(ad);
            return "The bloody jawler bit me with " + ad + " damage.\n";
        }
    }
}
