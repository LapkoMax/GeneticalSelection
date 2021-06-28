using GeneticalSelection.Models.Entities;
using GeneticalSelection.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories
{
    public interface IFamilyRepository
    {
        PagedList<Family> GetAllFamilies(QueryOptions options, bool trackChanges = false);
        Family GetFamily(long familyId, bool trackChanges = false);
        void CreateFamily(long orderId, Family family);
        void DeleteFamily(Family family);
    }
}
