using MySite.Data.Infrastructure;
using MySite.Entity.Entities.Persons;
using MySite.Entity.Models.PersonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySite.Data.Repositories.PersonsRepository
{
  public  interface IPersonRepository:IRepository<Person>
    {
        Task<IQueryable<PersonCreateOrEditModel>> GetPrunedData();
        bool AddAsynce(PersonCreateOrEditModel model);
        bool Edit(PersonCreateOrEditModel model);
    }
}
