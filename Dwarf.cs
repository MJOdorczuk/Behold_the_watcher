using System;
using System.Collections.Generic;
using System.Text;

namespace Behold_the_watcher
{
    class Dwarf
    {
        private List<Key> keys;
        private List<Key> closed;
        private int toBuild;
        private Room current;
        private List<Item> toHide;
        private List<Actor> toPlant;
        private List<Creature> toHatch;

        public Dwarf(List<Key> keys, int toBuild, List<Item> toHide, List<Actor> toPlant, List<Creature> toHatch)
        {
            this.keys = keys;
            this.current = new Room();
            this.toBuild = toBuild;
            this.toHide = toHide;
            this.toPlant = toPlant;
            this.toHatch = toHatch;
            this.closed = new List<Key>();
        }

        public Room Build()
        {
            while(toBuild - keys.Count + toHatch.Count + toHide.Count + toPlant.Count > 0)
            {

            }
            return null;
        }

        private bool MakeMove(int toDo)
        {
            int roomGrade = toBuild - keys.Count;
            int itemGrade = toHide.Count + keys.Count;
            int actorGrade = toPlant.Count;
            int creatureGrade = toHatch.Count;
            int rndcnt = new Random().Next(roomGrade + itemGrade + actorGrade + creatureGrade - 1);
            if(rndcnt < roomGrade)
            {
                Door portal = current.GoTo(Direction.RandomDirection);
            }
            return false;
        }
    }
}
