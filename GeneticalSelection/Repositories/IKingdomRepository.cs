using GeneticalSelection.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories
{
    public interface IKingdomRepository
    {
        IEnumerable<Kingdom> GetAllKingdoms(bool trackChanges = false);
        Kingdom GetKingdom(long kingdomId, bool trackChanges = false);
        void CreateKingdom(Kingdom kingdom);
    }
}
