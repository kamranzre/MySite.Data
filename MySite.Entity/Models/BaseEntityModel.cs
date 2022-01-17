using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySite.Entity.Models
{
   public class BaseEntityModel
    {
       
        public virtual long Id { get; set; }
    }
}
