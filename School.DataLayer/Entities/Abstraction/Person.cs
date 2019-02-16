using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataLayer.Entities.Abstraction
{
    public class Person : BaseEntity
    {
        [MaxLength(100)]
        public string Address { get; set; }

        public DateTime? BirthDate { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [ForeignKey("Gender")]
        public int GenderId { get; set; }

        public virtual Gender Gender { get; set; }
    }
}
