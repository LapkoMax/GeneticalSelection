using GeneticalSelection.Models.Entities;
using GeneticalSelection.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories
{
    public interface IKingdomRepository
    {
        PagedList<Kingdom> GetAllKingdoms(QueryOptions options, bool trackChanges = false);
        Kingdom GetKingdom(long kingdomId, bool trackChanges = false);
        void CreateKingdom(Kingdom kingdom);
        void DeleteKingdom(Kingdom kingdom);
    }
}
