using CriminalSearch.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalSearch.Repository.Repository
{
    public interface ICriminalRepository : IRepository<Criminal>
    {
        IList<Criminal> GetCriminalsByType(SearchType type, CriminalSearchItem searchItem);
    }
}
