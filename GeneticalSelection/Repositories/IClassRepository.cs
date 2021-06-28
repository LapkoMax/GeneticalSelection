using GeneticalSelection.Models.Entities;
using GeneticalSelection.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories
{
    public interface IClassRepository
    {
        PagedList<Class> GetAllClasses(QueryOptions options, bool trackChanges = false);
        Class GetClass(long classId, bool trackChanges = false);
        void CreateClass(long subphylumId, Class cl);
        void DeleteClass(Class cl);
    }
}
