using Catlang.Client.Models;
using System.Collections.Generic;

namespace Catlang.Client.Contracts
{
    class GetStudiedSetsResponse
    {
        public GetStudiedSetsResponse(List<StudiedSetDto> studiedSets)
        {
            StudiedSets = studiedSets;
        }

        public List<StudiedSetDto> StudiedSets { get; set; }
    }
}
