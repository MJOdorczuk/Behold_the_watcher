using System;
using System.Collections.Generic;
using System.Text;

namespace Behold_the_watcher
{
    // The controller
    class Beholder
    {
        private const string GO = "go";
        private const string EXAMINE = "examine";
        private const string TAKE = "take";
        private const string HIT = "hit";
        private const string SURRENDER = "surrender";
        private const string KIDDING = "kidding";
        private const string EQUIPEMENT = "eq";
        private const string FORWARD = "forward";
        private const string BACK = "back";
        private const string LEFT = "left";
        private const string RIGHT = "right";
        private const string UP = "up";
        private const string DOWN = "down";
        private const string HELP = "help";
        private const string commandList = GO + " - to move in one of directions {" + FORWARD + ", " + BACK
            + ", " + LEFT + ", " + RIGHT + ", " + UP + ", " + DOWN + "}\n"
            + EXAMINE + " - to examine one of the objects in the room\n"
            + TAKE + " - to take one of the objects in the room\n"
            + HIT + " - to hit one of the creatures in the room\n"
            + SURRENDER + " - to lose instantly\n"
            + KIDDING + " - to restart the game\n"
            + EQUIPEMENT + " - to see your inventory"
            + HELP + " - to display this message once more\n";

        private Dungeon playground;
        private Fiddler storyteller;
        private Func<Dungeon, bool> goal;
        public Beholder(Dungeon playground, Fiddler storyteller, Func<Dungeon,bool> goal)
        {
            this.playground = playground;
            this.storyteller = storyteller;
            this.goal = goal;
        }
        public void ChallangeTheWatcher()
        {
            String command = "";
            List<String> args = new List<String>();
            storyteller.Tell(commandList);
            storyteller.Hint(storyteller.BeginStory);
            storyteller.Hint(playground.ExamineThisHall());
            while (true)
            {
                command = Console.ReadLine();
                args.Clear();
                args.AddRange(command.Split(' '));
                switch(args[0])
                {
                    case GO:
                        {
                            switch(args[1])
                            {
                                case FORWARD:
                                    {
                                        storyteller.Tell(playground.Go(Direction.FORWARD));
                                        break;
                                    }
                                case BACK:
                                    {
                                        storyteller.Tell(playground.Go(Direction.BACKWARD));
                                        break;
                                    }
                                case LEFT:
                                    {
                                        storyteller.Tell(playground.Go(Direction.LEFT));
                                        break;
                                    }
                                case RIGHT:
                                    {
                                        storyteller.Tell(playground.Go(Direction.RIGHT));
                                        break;
                                    }
                                case UP:
                                    {
                                        storyteller.Tell(playground.Go(Direction.UPSTAIRS));
                                        break;
                                    }
                                case DOWN:
                                    {
                                        storyteller.Tell(playground.Go(Direction.DOWNSTAIRS));
                                        break;
                                    }
                                default:
                                    {
                                        storyteller.Repeat();
                                        break;
                                    }
                            }
                            break;
                        }
                    case EXAMINE:
                        {
                            Int32 index;
                            try
                            {
                                index = Convert.ToInt32(args[1]);
                            }
                            catch(Exception)
                            {
                                index = -1;
                            }
                            storyteller.Tell(playground.Examine(index));
                            break;
                        }
                    case TAKE:
                        {
                            Int32 index;
                            try
                            {
                                index = Convert.ToInt32(args[1]);
                            }
                            catch (Exception)
                            {
                                index = -1;
                            }
                            storyteller.Tell(playground.Take(index));
                            break;
                        }
                    case HIT:
                        {
                            Int32 index;
                            try
                            {
                                index = Convert.ToInt32(args[1]);
                            }
                            catch (Exception)
                            {
                                index = -1;
                            }
                            storyteller.Tell(playground.Hit(index));
                            break;
                        }
                    case SURRENDER:
                        {
                            storyteller.EndWith(Surrender());
                            return;
                        }
                    case KIDDING:
                        {
                            playground.Rebuild();
                            storyteller.Tell(storyteller.BeginStory);
                            break;
                        }
                    case EQUIPEMENT:
                        {
                            storyteller.Tell(playground.GetWanderer().Bagpack());
                            break;
                        }
                    case HELP:
                        {
                            storyteller.Tell(commandList);
                            break;
                        }
                    default:
                        {
                            storyteller.Repeat();
                            break;
                        }
                }
                if(!playground.GetWanderer().IsAlive())
                {
                    storyteller.Hint(End());
                    command = Console.ReadLine();
                    if(command.Split(' ')[0] == KIDDING)
                    {
                        playground.Rebuild();
                        storyteller.Tell(storyteller.BeginStory);
                        storyteller.Hint(playground.ExamineThisHall());
                    }
                }
                else
                {
                    if (goal(playground))
                    {
                        storyteller.Hint("And that's how this story ends.\n");
                        return;
                    }
                    storyteller.Hint(playground.MakeTurn());
                    storyteller.Hint(playground.ExamineThisHall());
                }
            }
        }
        private string End()
        {
            return "Hahaha! You dieded, you pathetic creature!";
        }
        private string Surrender()
        {
            return "Pathetic coward.";
        }
    }
}
