using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Models.Entities
{
    public class Phylum //Type
    {
        [Column("PhylumId")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Phylum name is a required field.")]
        [MaxLength(100, ErrorMessage = "Max length for the phylum's name is 100 characters.")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "Max length for the phylum's latin name is 200 characters.")]
        public string LatinName { get; set; }

        [MaxLength(200, ErrorMessage = "Max length for the phylum's description is 200 characters.")]
        public string Description { get; set; }
        [ForeignKey(nameof(Kingdom))]
        public long KingdomId { get; set; }
        public Kingdom Kingdom { get; set; }
        public ICollection<Subphylum> Subphylums { get; set; }
    }
}
