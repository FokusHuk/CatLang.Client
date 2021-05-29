using Catlang.Client.Models;
using System.Collections.Generic;

namespace Catlang.Client.Contracts
{
    class GetCreatedSetsResponse
    {
        public GetCreatedSetsResponse(List<CreatedSetDto> createdSets)
        {
            CreatedSets = createdSets;
        }

        public List<CreatedSetDto> CreatedSets { get; set; }
    }
}
