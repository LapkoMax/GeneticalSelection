using GeneticalSelection.Models.Entities;
using GeneticalSelection.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories
{
    public interface ISubphylumRepository
    {
        PagedList<Subphylum> GetAllSubphylums(QueryOptions options, bool trackChanges = false);
        Subphylum GetSubphylum(long subphylumId, bool trackChanges = false);
        void CreateSubphylum(long phylumId, Subphylum subphylum);
        void DeleteSubphylum(Subphylum subphylum);
    }
}
