using System.Collections.Generic;

namespace MyTemplate.Domain.Entities.Dtos
{
    public class SearchResult<TResultType, TSearchParameter>
    {
        public TSearchParameter SearchParameter { get; set; }
        public List<TResultType> Result { get; set; }
        public int TotalCount { get; set; }
    }
}
