using Catlang.Client.Models;
using System.Collections.Generic;

namespace Catlang.Client.Contracts
{
    class GetAllWordsResponse
    {
        public GetAllWordsResponse(List<Word> words)
        {
            Words = words;
        }

        public List<Word> Words { get; set; }
    }
}
