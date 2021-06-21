using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Models.Entities
{
    public class Family
    {
        [Column("FamilyId")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Family name is a required field.")]
        [MaxLength(100, ErrorMessage = "Max length for the family's name is 100 characters.")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "Max length for the family's latin name is 200 characters.")]
        public string LatinName { get; set; }

        [MaxLength(200, ErrorMessage = "Max length for the family's description is 200 characters.")]
        public string Description { get; set; }
        [ForeignKey(nameof(Order))]
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public ICollection<Genus> Genuses { get; set; }
    }
}
