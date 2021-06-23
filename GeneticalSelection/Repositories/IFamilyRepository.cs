using GeneticalSelection.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories
{
    public interface IFamilyRepository
    {
        IEnumerable<Family> GetAllFamilies(bool trackChanges = false);
        Family GetFamily(long familyId, bool trackChanges = false);
        void CreateFamily(long orderId, Family family);
    }
}
