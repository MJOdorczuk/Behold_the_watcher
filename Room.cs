using System;
using System.Collections.Generic;
using System.Text;

namespace Behold_the_watcher
{
    class Room
    {
        private List<Actor> staticActors;
        private List<Creature> dwellers;
        private Door north, east, south, west, upstairs, downstairs;
        public Room()
        {
            north = east = south = west = upstairs = downstairs = null;
            staticActors = new List<Actor>();
            dwellers = new List<Creature>();
        }
        public void SetDoor(Door door, int direction)
        {
            switch(direction)
            {
                case Direction.FORWARD:
                    {
                        north = door;
                        break;
                    }
                case Direction.RIGHT:
                    {
                        east = door;
                        break;
                    }
                case Direction.BACKWARD:
                    {
                        south = door;
                        break;
                    }
                case Direction.LEFT:
                    {
                        west = door;
                        break;
                    }
                case Direction.UPSTAIRS:
                    {
                        upstairs = door;
                        break;
                    }
                case Direction.DOWNSTAIRS:
                    {
                        downstairs = door;
                        break;
                    }
                default:
                    {
                        throw new Exception("No possible passage to add at this direction");
                    }
            }
        }
        public void AddStaticActor(Actor staticActor) => staticActors.Add(staticActor);
        public List<Actor> GetStaticActors() => staticActors;
        public List<Creature> GetDwellers() => dwellers;
        public Door GoTo(int where)
        {
            switch(where)
            {
                case 0:
                    {
                        return north;
                    }
                case 1:
                    {
                        return east;
                    }
                case 2:
                    {
                        return south;
                    }
                case 3:
                    {
                        return west;
                    }
                case 4:
                    {
                        return upstairs;
                    }
                case 5:
                    {
                        return downstairs;
                    }
                default:
                    {
                        throw new Exception("No such direction");
                    }
            }
        }
        public String Examine(int face)
        {
            String ret = "";
            if (GoTo(face) != null)
                ret += "There was a door ahead of me.\n";
            if (GoTo((face + 3) % 4) != null)
                ret += "There was a door to the left.\n";
            if (GoTo((face + 1) % 4) != null)
                ret += "There was a door to the right.\n";
            if (GoTo((face + 2) % 4) != null)
                ret += "There was a door behind me.\n";
            if (upstairs != null)
                ret += "There were stairs to the upper floor.\n";
            if (downstairs != null)
                ret += "There was a way downwards.\n";
            if(staticActors.Count != 0)
            {
                ret += "\nIn the room I saw:\n";
                for (int i = 0; i < staticActors.Count; i++)
                    ret += " - " + i + " - " + staticActors[i].Name() + "\n";
            }
            if(dwellers.Count != 0)
            {
                ret += "\nI had to challange:\n";
                for (int i = 0; i < dwellers.Count; i++)
                    ret += " - " + i + " - " + dwellers[i].Name() + "\n";
            }
            return ret;
        }
    }
}
