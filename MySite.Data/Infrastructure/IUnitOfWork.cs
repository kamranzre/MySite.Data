using Microsoft.EntityFrameworkCore;
using MySite.Data.Repositories.PersonsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySite.Data.Infrastructure
{
   public interface IUnitOfWork<TContext>:IDisposable where TContext:DbContext
    {
        //begin TransAction  //CommitDb(Savechange) rollBack(NoSavechange)
       
        PersonRepository PersonRepository{ get; }
        void Savechange();
        Task<int> SaveChangeAsynce();
    }
}
