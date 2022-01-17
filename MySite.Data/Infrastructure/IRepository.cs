using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MySite.Data.Infrastructure
{
   public interface IRepository<TEntity>where TEntity:class
    {
        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(long Id);

        void Delete(TEntity entity);

        void Delete(Expression<Func<TEntity, bool>> where);

        TEntity GetById(long Id);

        IEnumerable<TEntity> GetAll();

        TEntity GetItem(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetItems(Expression<Func<TEntity, bool>> where);

        //Async
        Task<List<TEntity>> GetAllAsynce();
        Task<TEntity> GetAsynce(long Id);
        Task<List<TEntity>> GetItemsAsynce(Expression<Func<TEntity, bool>> where);


        IQueryable<TEntity> TableNoTracking { get; }

    }
}
