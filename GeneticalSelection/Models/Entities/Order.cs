using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Models.Entities
{
    public class Order
    {
        [Column("OrderId")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Order name is a required field.")]
        [MaxLength(100, ErrorMessage = "Max length for the order's name is 100 characters.")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "Max length for the order's latin name is 200 characters.")]
        public string LatinName { get; set; }

        [MaxLength(200, ErrorMessage = "Max length for the order's description is 200 characters.")]
        public string Description { get; set; }
        [ForeignKey(nameof(Class))]
        public long ClassId { get; set; }
        public Class Class { get; set; }
        public ICollection<Family> Families { get; set; }
    }
}
