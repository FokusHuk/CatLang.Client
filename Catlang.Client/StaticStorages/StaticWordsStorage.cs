using Catlang.Client.Models;
using System.Collections.Generic;

namespace Catlang.Client.StaticStorages
{
    public static class StaticWordsStorage
    {
        public static List<WordDto> Words { get; set; }

        public static bool DoesWordsLoaded = false;
    }
}
