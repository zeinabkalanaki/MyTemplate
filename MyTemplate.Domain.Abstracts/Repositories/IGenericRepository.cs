using MyTemplate.Domain.Entities;
using MyTemplate.Domain.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Abstracts.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        public IQueryable<T> Get(params Expression<Func<T, object>>[] including);
        Task<int> Insert(T entity);
        Task InsertRange(IEnumerable<T> entities);
        Task Update(T entity, params Expression<Func<T, object>>[] updatedProperties);
        void Delete(int id);
        void DeleteRange(IEnumerable<T> entities);
        SearchResult<T, BaseSearchParameter> GetList(BaseSearchParameter searchParameters);
    }
}
