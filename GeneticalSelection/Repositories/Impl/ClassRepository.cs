using GeneticalSelection.Models;
using GeneticalSelection.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories.Impl
{
    public class ClassRepository : RepositoryBase<Class>, IClassRepository
    {
        public ClassRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
    }
}
