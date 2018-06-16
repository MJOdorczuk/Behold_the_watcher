using System;
using System.Collections.Generic;
using System.Text;

namespace Behold_the_watcher
{
    static class Direction
    {
        public const int FORWARD = 0;
        public const int RIGHT = 1;
        public const int BACKWARD = 2;
        public const int LEFT = 3;
        public const int UPSTAIRS = 4;
        public const int DOWNSTAIRS = 5;

        public static int Turn(int face, int rotation)
        {
            if ((face < 4 && rotation < 4) || face < 0 || rotation < 0)
                return (face + rotation) % 4;
            else if (rotation == 4 || rotation == 5)
                return rotation;
            else throw new Exception("Turn not possible");
        }
        public static int Reverse(int direction)
        {
            switch(direction)
            {
                case FORWARD:
                    {
                        return BACKWARD;
                    }
                case RIGHT:
                    {
                        return LEFT;
                    }
                case BACKWARD:
                    {
                        return FORWARD;
                    }
                case LEFT:
                    {
                        return RIGHT;
                    }
                case UPSTAIRS:
                    {
                        return DOWNSTAIRS;
                    }
                case DOWNSTAIRS:
                    {
                        return UPSTAIRS;
                    }
                default:
                    {
                        throw new Exception("Not known direction");
                    }
            }
        }

        public static int RandomDirection => new Random().Next(0, 5);
    }
}
