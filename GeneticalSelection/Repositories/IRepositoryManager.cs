using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories
{
    public interface IRepositoryManager
    {
        IKingdomRepository Kingdom { get; }
        IPhylumRepository Phylum { get; }
        ISubphylumRepository Subphylum { get; }
        IClassRepository Class { get; }
        IOrderRepository Order { get; }
        IFamilyRepository Family { get; }
        IGenusRepository Genus { get; }
        ISpeciesRepository Species { get; }
        void Save();
    }
}
