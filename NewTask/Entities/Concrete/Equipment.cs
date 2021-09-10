using Core.Entities;

using DataAnnotationsExtensions;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Equipment:IEntity
    {
        public int Id { get; set; }

        [Required]
        [Min(1)]
        public int ClinicId { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(149)]
        public string Name { get; set; }

        public DateTime AvialabilityDate { get; set; }

        [Required]
        [Min(1)]
        public int Count { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal UnitPrice { get; set; }

        [Range(typeof(decimal), "0", "100")]
        public decimal UsingRate { get; set; }
    }
}
