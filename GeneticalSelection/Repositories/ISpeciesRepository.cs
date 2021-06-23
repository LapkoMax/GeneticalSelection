using GeneticalSelection.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories
{
    public interface ISpeciesRepository
    {
        IEnumerable<Species> GetAllSpecies(bool trackChanges = false);
        Species GetSpecies(long speciesId, bool trackChanges = false);
        void CreateSpecies(long genusId, Species species);
    }
}
