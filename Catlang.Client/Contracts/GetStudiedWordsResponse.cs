using Catlang.Client.Models;
using System.Collections.Generic;

namespace Catlang.Client.Contracts
{
    class GetStudiedWordsResponse
    {
        public GetStudiedWordsResponse(List<StudiedWordDto> studiedWords)
        {
            StudiedWords = studiedWords;
        }

        public List<StudiedWordDto> StudiedWords { get; set; }
    }
}
