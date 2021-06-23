using GeneticalSelection.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories
{
    public interface IGenusRepository
    {
        IEnumerable<Genus> GetAllGenuses(bool trackChanges = false);
        Genus GetGenus(long genusId, bool trackChanges = false);
        void CreateGenus(long familyId, Genus genus);
    }
}
