using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management_System.Entity.Repositories;

namespace Hospital_Management_System.Entity.UnitOfWorks
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<T> GetRepository<T>() where T : class, new();

		void Commit();		//içine SaveChanges();
		Task CommitAsync();
	}
}
