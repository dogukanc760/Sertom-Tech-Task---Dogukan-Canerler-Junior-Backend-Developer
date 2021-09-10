using Core.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Clinics:IEntity
    {
        
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        [MinLength(10)]
        public string Name { get; set; }

    }
}
