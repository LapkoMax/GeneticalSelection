using GeneticalSelection.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories
{
    public interface ISubphylumRepository
    {
        IEnumerable<Subphylum> GetAllSubphylums(bool trackChanges = false);
        Subphylum GetSubphylum(long subphylumId, bool trackChanges = false);
        void CreateSubphylum(long phylumId, Subphylum subphylum);
    }
}
