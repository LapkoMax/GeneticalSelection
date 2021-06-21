using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Models.Entities
{
    public class Class
    {
        [Column("ClassId")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Class name is a required field.")]
        [MaxLength(100, ErrorMessage = "Max length for the class's name is 100 characters.")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "Max length for the class's latin name is 200 characters.")]
        public string LatinName { get; set; }

        [MaxLength(200, ErrorMessage = "Max length for the class's description is 200 characters.")]
        public string Description { get; set; }
        [ForeignKey(nameof(Subphylum))]
        public long SubphylumId { get; set; }
        public Subphylum Subphylum { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
