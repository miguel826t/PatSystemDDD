using Microsoft.EntityFrameworkCore;
using PatSystem.Domain.Entities;
using PatSystem.Domain.Interfaces;
using PatSystem.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PatSystem.Infra.Repository
{
	public class BaseRepository<T> : IRepository<T> where T : BaseEntity
	{
		private readonly PatSystemContext _context;
		private readonly DbSet<T> _dbEntitySet;

		public BaseRepository(PatSystemContext context)
		{
			_context = context;
			_dbEntitySet = _context.Set<T>();
		}

		public virtual async Task InsertAsync(T obj)
		{
			_dbEntitySet.Add(obj);
			await _context.SaveChangesAsync();
		}

		public virtual async Task UpdateAsync(T obj)
		{
			_context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			await _context.SaveChangesAsync();
		}


		public virtual async Task<T> FindByIdAsync(int id)
		{
			return await _dbEntitySet.FindAsync(id);
		}

		public virtual async Task<IList<T>> FindAllAsync()
		{
			return await _dbEntitySet.ToListAsync();
		}

		public virtual async Task<IList<T>> FindAllOrderByDescAsync(Expression<Func<T, bool>> orderExpression)
		{
			return await _dbEntitySet.OrderByDescending(orderExpression).ToListAsync();
		}

		public virtual async Task<T> FindLast(Expression<Func<T, object>> orderExpression)
		{
			return await _dbEntitySet.OrderBy(orderExpression).LastAsync();
		}
		public virtual async Task<T> FindFist(Expression<Func<T, object>> orderExpression)
		{
			return await _dbEntitySet.OrderBy(orderExpression).FirstAsync();
		}

		public virtual async Task<IList<T>> FindAllByWhereExpressionAsync(Expression<Func<T, bool>> expression)
		{
			return await _dbEntitySet.Where(expression).ToListAsync();
		}

		public virtual async Task<IList<T>> FindAllByWhereExpressionWhitOrderByDescAsync(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderExpression)
		{
			return await _dbEntitySet.Where(whereExpression).OrderByDescending(orderExpression).ToListAsync();
		}

		public virtual async Task<IList<T>> FindAllByWhereExpressionWhitOrderByAsync(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderExpression)
		{
			return await _dbEntitySet.Where(whereExpression).OrderBy(orderExpression).ToListAsync();
		}

	}
}
