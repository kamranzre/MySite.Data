using Microsoft.EntityFrameworkCore;

using MySite.Entity.Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySite.Data.DataBaseContext
{
     public class MySiteDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-VDF03R7\\LOCAL;Database=CRUD;Integrated Security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Person>(x=> {
                x.Property(x => x.Id).ValueGeneratedOnAdd();
            });
           
            //base.OnModelCreating(modelBuilder);
        }

     
        public DbSet<Person> Person{ get; set; }
    }
}
