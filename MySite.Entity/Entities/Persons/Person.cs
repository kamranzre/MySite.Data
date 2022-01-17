using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySite.Entity.Entities.Persons
{
   public class Person:BaseEntity
    {
        public string Name { get; set; }

        public string FName { get; set; }

        public string NationalCode { get; set; }

        public string PhoneNumber { get; set; }
    }
}
