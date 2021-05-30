using Catlang.Client.Models;
using System.Collections.Generic;

namespace Catlang.Client.Contracts
{
    class GetAllWordsResponse
    {
        public GetAllWordsResponse(List<WordDto> words)
        {
            Words = words;
        }

        public List<WordDto> Words { get; set; }
    }
}
