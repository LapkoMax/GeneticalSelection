using GeneticalSelection.Models.Entities;
using GeneticalSelection.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories
{
    public interface IGenusRepository
    {
        PagedList<Genus> GetAllGenuses(QueryOptions options, bool trackChanges = false);
        Genus GetGenus(long genusId, bool trackChanges = false);
        void CreateGenus(long familyId, Genus genus);
        void DeleteGenus(Genus genus);
    }
}
