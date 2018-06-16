using System;
using System.Collections.Generic;

namespace Behold_the_watcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Fiddler storyteller = new Fiddler();
            Beholder beholder = new Beholder(new Dungeon(LevelGenerator.GenericGenerator(),new Hero(new List<Item>(),5,5,"String")), storyteller, LevelGenerator.GenericGoal());
            beholder.ChallangeTheWatcher();
        }
    }
}
