using Catlang.Client.Models;
using System.Collections.Generic;

namespace Catlang.Client
{
    public static class StaticWordsStorage
    {
        public static List<Word> Words { get; set; }

        public static bool DoesWordsLoaded = false;
    }
}
