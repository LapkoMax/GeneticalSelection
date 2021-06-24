using GeneticalSelection.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories
{
    public interface IClassRepository
    {
        IEnumerable<Class> GetAllClasses(bool trackChanges = false);
        Class GetClass(long classId, bool trackChanges = false);
        void CreateClass(long subphylumId, Class cl);
        void DeleteClass(Class cl);
    }
}
