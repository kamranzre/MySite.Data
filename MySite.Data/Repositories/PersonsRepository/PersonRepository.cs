using Microsoft.EntityFrameworkCore;
using MySite.Data.DataBaseContext;
using MySite.Data.Infrastructure;
using MySite.Entity.Entities.Persons;
using MySite.Entity.Mapper.Extensions;
using MySite.Entity.Models.PersonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySite.Data.Repositories.PersonsRepository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private readonly DbContext db;


        public PersonRepository(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (MySiteDbContext)db);

        }

        public async Task<IQueryable<PersonCreateOrEditModel>> GetPrunedData()
        {
            var person = TableNoTracking.ToModel<PersonCreateOrEditModel>().AsQueryable();
            return person;
        }

        public bool AddAsynce(PersonCreateOrEditModel model)
        {
            try
            {
                if (model.Name != null && model.Id == 0)
                {
                    var entity = model.ToEntity<Person>();
                    Insert(entity);
                    return true;

                }
                return false;


            }
            catch (Exception ex)
            {

                throw;
            }
            return false;

        }

        public bool Edit(PersonCreateOrEditModel model)
        {
            try
            {
                var entity = model.ToEntity<Person>();
               //Person person = new Person()
               //{
               //    Id = model.Id,
               //    Name = model.Name,
               //    FName = model.FName,
               //    NationalCode = model.NationalCode,
               //    PhoneNumber = model.PhoneNumber
               //};
                Update(entity);
                return true;


            }
            catch (Exception ex)
            {
                return false;

            }

        }

        public bool DeleteAsynce(long id)
        {
            try
            {

                if (id != null || id != 0)
                {
                    var entity = TableNoTracking.Where(x => x.Id == id).FirstOrDefault();
                    if (entity != null)
                    {
                        Delete(entity);
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
