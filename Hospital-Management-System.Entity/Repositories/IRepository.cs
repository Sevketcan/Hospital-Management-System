using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Entity.Repositories
{
	public interface IRepository<T> where T : class, new()
	{
		//List<T> GetAll();

		Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter=null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby=null, params Expression<Func<T, object>>[] includes);	
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		Task<T> Get(Expression<Func<T, bool>> filter);
		Task Add(T entity);
		void Update(T entity);
		void Delete(int id);
		void Delete(T entity);
	}
}
