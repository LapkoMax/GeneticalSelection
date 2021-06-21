using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Models.Entities
{
    public class Species
    {
        [Column("SpeciesId")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Species name is a required field.")]
        [MaxLength(100, ErrorMessage = "Max length for the species's name is 100 characters.")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "Max length for the species's latin name is 200 characters.")]
        public string LatinName { get; set; }

        [MaxLength(200, ErrorMessage = "Max length for the species's description is 200 characters.")]
        public string Description { get; set; }
        [ForeignKey(nameof(Genus))]
        public long GenusId { get; set; }
        public Genus Genus { get; set; }
    }
}
