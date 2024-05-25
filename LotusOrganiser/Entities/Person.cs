using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusOrganiser.Entities
{
    public sealed class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PersonId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
