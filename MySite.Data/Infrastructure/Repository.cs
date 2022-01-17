using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MySite.Data.Infrastructure
{
    public abstract class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        private readonly DbContext _db;

        private DbSet<TEntity> dbSet
        {
            get
            {
                return _db.Set<TEntity>();
            }
        }

        public virtual IQueryable<TEntity> TableNoTracking => dbSet.AsNoTracking();

        public Repository(DbContext db)
        {
            _db = db;
        }
        public void Delete(long Id)
        {
            var entity =GetById(Id);
            if (entity == null)
            throw new ArgumentException("No Entity");
            dbSet.Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            _db.SaveChanges();
            
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> obj = dbSet.Where(where).AsEnumerable();
            foreach (TEntity item in obj)
            {
                dbSet.Remove(item);
            }
        }

       

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public async Task<List<TEntity>> GetAllAsynce()
        {
           return await dbSet.ToListAsync();
        }

        public async Task<TEntity> GetAsynce(long Id)
        {
           if(Id != 0)
            {
                return await dbSet.FindAsync(Id);
            }
            return null;
        }

        public TEntity GetById(long Id)
        {
            return dbSet.Find(Id);
        }

        public TEntity GetItem(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetItems(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public async Task<List<TEntity>> GetItemsAsynce(Expression<Func<TEntity, bool>> where)
        {
            return await dbSet.Where(where).ToListAsync();
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            _db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("No Entity");
            dbSet.Update(entity);
            _db.SaveChanges();

        }



        private bool disposed = false;
        protected virtual void Dispose(bool disposed)
        {
            if (!disposed)
            {
                if (disposed)
                {
                    _db.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
