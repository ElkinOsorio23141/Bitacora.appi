using Ekisa.Api.BotFetal.Configuration;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bitacora.Api.Interfaces
{
    public interface IRepository<T> where T : class
    {

        Response GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        Response GetObjectByCondition(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        Response GetAllObjectsByCondition(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null, bool isLoadingAll = true, int skip = 0, int take = 0);
        Response FindAllByConditionInclude(Expression<Func<T, bool>> predicate, params string[] includes);
        Response FindOneByConditionInclude(Expression<Func<T, bool>> predicate, params string[] includes);
        Response Create(T entity);
        Response CreateWithRelated(T entity);
        Response CreateListWithRelated(IEnumerable<T> entity);
        Response Update(T entity);
        Task<Response> UpdateAsync(T entity);

        Response UpdateSpecificProperties(T entity, params string[] properties);
        Response UpdateWithRelated(T entity);
        Response UpdateListWithRelated(IEnumerable<T> entity);
        Response Delete(T entity);
        Task<Response> DeleteById(dynamic id);
        Response DeleteWithRelated(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        Task<Response> TruncateEntity(dynamic entity);

        //Response GetAllPaginateFilter(Expression<Func<T, bool>> predicate, int take = 5, int page = 1, string[] filter = null, params string[] includes);


    }
}
