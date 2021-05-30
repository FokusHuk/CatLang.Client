using Catlang.Client.Models;
using System.Collections.Generic;

namespace Catlang.Client.Contracts
{
    class GetAllSetsResponse
    {
        public GetAllSetsResponse(List<SetDto> sets)
        {
            Sets = sets;
        }

        public List<SetDto> Sets { get; set; }
    }
}
