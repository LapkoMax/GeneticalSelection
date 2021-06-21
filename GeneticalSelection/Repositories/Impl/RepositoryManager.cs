using GeneticalSelection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories.Impl
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IKingdomRepository _kingdomRepository;
        private IPhylumRepository _phylumRepository;
        private ISubphylumRepository _subphylumRepository;
        private IClassRepository _classRepository;
        private IOrderRepository _orderRepository;
        private IFamilyRepository _familyRepository;
        private IGenusRepository _genusRepository;
        private ISpeciesRepository _speciesRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IKingdomRepository Kingdom 
        {
            get
            {
                if (_kingdomRepository == null)
                    _kingdomRepository = new KingdomRepository(_repositoryContext);
                return _kingdomRepository;
            }
        }
        public IPhylumRepository Phylum 
        {
            get
            {
                if (_phylumRepository == null)
                    _phylumRepository = new PhylumRepository(_repositoryContext);
                return _phylumRepository;
            }
        }
        public ISubphylumRepository Subphylum 
        {
            get
            {
                if (_subphylumRepository == null)
                    _subphylumRepository = new SubphylumRepository(_repositoryContext);
                return _subphylumRepository;
            }
        }
        public IClassRepository Class 
        {
            get
            {
                if (_classRepository == null)
                    _classRepository = new ClassRepository(_repositoryContext);
                return _classRepository;
            }
        }
        public IOrderRepository Order 
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(_repositoryContext);
                return _orderRepository;
            }
        }
        public IFamilyRepository Family
        {
            get
            {
                if (_familyRepository == null)
                    _familyRepository = new FamilyRepository(_repositoryContext);
                return _familyRepository;
            }
        }
        public IGenusRepository Genus
        {
            get
            {
                if (_genusRepository == null)
                    _genusRepository = new GenusRepository(_repositoryContext);
                return _genusRepository;
            }
        }
        public ISpeciesRepository Species
        {
            get
            {
                if (_speciesRepository == null)
                    _speciesRepository = new SpeciesRepository(_repositoryContext);
                return _speciesRepository;
            }
        }
        public void Save() => _repositoryContext.SaveChanges();
    }
}
