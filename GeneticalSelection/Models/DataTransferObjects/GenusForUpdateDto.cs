using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Models.DataTransferObjects
{
    public class GenusForUpdateDto
    {
        public string Name { get; set; }
        public string LatinName { get; set; }
        public string Description { get; set; }
        public long FamilyId { get; set; }
    }
}
