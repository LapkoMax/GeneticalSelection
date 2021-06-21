using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Models.Entities
{
    public class Kingdom
    {
        [Column("KingdomId")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Kingdom name is a required field.")]
        [MaxLength(100, ErrorMessage = "Max length for the kingdom's name is 100 characters.")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "Max length for the kingdom's latin name is 200 characters.")]
        public string LatinName { get; set; }

        [MaxLength(200, ErrorMessage = "Max length for the kingdom's description is 200 characters.")]
        public string Description { get; set; }
        public ICollection<Phylum> Phylums { get; set; }
    }
}
