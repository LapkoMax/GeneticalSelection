using GeneticalSelection.Models.Entities;
using GeneticalSelection.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories
{
    public interface IPhylumRepository
    {
        PagedList<Phylum> GetAllPhylums(QueryOptions options, bool trackChanges = false);
        Phylum GetPhylum(long phylumId, bool trackChanges = false);
        void CreatePhylum(long kingdomId, Phylum phylum);
        void DeletePhylum(Phylum phylum);
    }
}
