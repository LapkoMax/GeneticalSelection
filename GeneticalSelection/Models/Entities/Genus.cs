using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Models.Entities
{
    public class Genus
    {
        [Column("GenusId")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Genus name is a required field.")]
        [MaxLength(100, ErrorMessage = "Max length for the genus's name is 100 characters.")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "Max length for the genus's latin name is 200 characters.")]
        public string LatinName { get; set; }

        [MaxLength(200, ErrorMessage = "Max length for the genus's description is 200 characters.")]
        public string Description { get; set; }
        [ForeignKey(nameof(Family))]
        public long FamilyId { get; set; }
        public Family Family { get; set; }
        public ICollection<Species> Species { get; set; }
    }
}
