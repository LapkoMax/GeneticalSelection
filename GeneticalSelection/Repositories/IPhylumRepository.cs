using GeneticalSelection.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories
{
    public interface IPhylumRepository
    {
        IEnumerable<Phylum> GetAllPhylums(bool trackChanges = false);
        Phylum GetPhylum(long phylumId, bool trackChanges = false);
        void CreatePhylum(long kingdomId, Phylum phylum);
        void DeletePhylum(Phylum phylum);
    }
}
