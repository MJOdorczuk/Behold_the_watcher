using System;
using System.Collections.Generic;
using System.Text;

namespace Behold_the_watcher
{
    abstract class Creature : Actor
    {
        protected int hp;
        protected readonly int ad;
        

        public Creature(List<Item> equipment, int ad, int hp) : base(equipment)
        {
            this.ad = ad;
            this.hp = hp;
        }

        public void Damage(int damage) => hp -= damage;

        public bool IsAlive() => hp >= 0;
        internal abstract string MakeAction(Hero wanderer, Room hall);
    }
}
