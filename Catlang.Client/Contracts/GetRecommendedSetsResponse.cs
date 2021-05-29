using System;
using System.Collections.Generic;

namespace Catlang.Client.Contracts
{
    class GetRecommendedSetsResponse
    {
        public GetRecommendedSetsResponse(List<Guid> recommendedSets)
        {
            RecommendedSets = recommendedSets;
        }

        public List<Guid> RecommendedSets { get; set; }
    }
}
