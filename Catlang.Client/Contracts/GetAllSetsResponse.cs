using Catlang.Client.Models;
using System.Collections.Generic;

namespace Catlang.Client.Contracts
{
    class GetAllSetsResponse
    {
        public GetAllSetsResponse(List<Set> sets)
        {
            Sets = sets;
        }

        public List<Set> Sets { get; set; }
    }
}
