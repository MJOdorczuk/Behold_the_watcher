using System;
using System.Collections.Generic;
using System.Text;

namespace Behold_the_watcher
{
    // The view
    class Fiddler
    {
        private string last;

        internal string BeginStory => "Long time ago, I was wandering through the mysterious caverns.\n";

        internal void Tell(string v)
        {
            Console.Clear();
            last = v;
            Console.WriteLine(v);
        }

        internal void Hint(string v)
        {
            Console.WriteLine(v);
        }

        internal void Repeat()
        {
            Console.Clear();
            Console.WriteLine(last);
        }

        internal void EndWith(string v)
        {
            Console.Clear();
            Console.WriteLine(v);
        }
    }
}
