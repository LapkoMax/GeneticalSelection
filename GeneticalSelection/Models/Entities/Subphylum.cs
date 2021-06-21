using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Models.Entities
{
    public class Subphylum  //Subtype
    {
        [Column("SubphylumId")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Subphylum name is a required field.")]
        [MaxLength(100, ErrorMessage = "Max length for the subphylum's name is 100 characters.")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "Max length for the subphylum's latin name is 200 characters.")]
        public string LatinName { get; set; }

        [MaxLength(200, ErrorMessage = "Max length for the subphylum's description is 200 characters.")]
        public string Description { get; set; }
        [ForeignKey(nameof(Phylum))]
        public long PhylumId { get; set; }
        public Phylum Phylum { get; set; }
        public ICollection<Class> Classes { get; set; }
    }
}
