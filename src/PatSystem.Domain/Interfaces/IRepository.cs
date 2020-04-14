using PatSystem.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatSystem.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task InsertAsync(T obj);

        Task UpdateAsync(T obj);

        Task<T> FindByIdAsync(int id);

        Task<IList<T>> FindAllAsync();

        Task<IList<T>> FindAllOrderByDescAsync(Expression<Func<T, bool>> expression);

        Task<T> FindLast(Expression<Func<T, object>> orderExpression);

        Task<T> FindFist(Expression<Func<T, object>> orderExpression);

        Task<IList<T>> FindAllByWhereExpressionAsync(Expression<Func<T, bool>> expression);

        Task<IList<T>> FindAllByWhereExpressionWhitOrderByDescAsync(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderExpression);

        Task<IList<T>> FindAllByWhereExpressionWhitOrderByAsync(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderExpression);



    }
}
