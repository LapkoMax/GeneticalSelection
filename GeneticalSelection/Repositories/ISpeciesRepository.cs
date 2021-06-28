using GeneticalSelection.Models.Entities;
using GeneticalSelection.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories
{
    public interface ISpeciesRepository
    {
        PagedList<Species> GetAllSpecies(QueryOptions options, bool trackChanges = false);
        Species GetSpecies(long speciesId, bool trackChanges = false);
        void CreateSpecies(long genusId, Species species);
        void DeleteSpecies(Species species);
    }
}
