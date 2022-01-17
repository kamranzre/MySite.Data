using Microsoft.EntityFrameworkCore;
using MySite.Data.Repositories.PersonsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySite.Data.Infrastructure
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        protected readonly DbContext db;
        #region Ctor
        public UnitOfWork()
        {
            db = new TContext();

        }
        #endregion

        #region Impeliment
        public void Savechange()
        {
            db.SaveChanges();
        }

        public async Task<int> SaveChangeAsynce()
        {
            return await db.SaveChangesAsync();
        }
        #endregion

        

        #region PersonRepository
        private PersonRepository _PersonRepository;
        public PersonRepository PersonRepository
        {
            get
            {
                if(_PersonRepository == null)
                {
                    _PersonRepository = new PersonRepository(db);
                }
                return _PersonRepository;
            }
        }
        #endregion

        #region Dispose
        private bool disposed = false;


      
        protected virtual void Dispose(bool disposed)
        {
            if (!disposed)
            {
                if (disposed)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

       
    }
}
