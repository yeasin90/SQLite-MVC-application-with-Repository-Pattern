using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalSearch.Repository.Entity
{
    [Serializable]
    public enum SearchType
    {
        Name,
        Age,
        Sex,
        Height,
        Nationality
    }

    public enum Gender
    {
        Male,
        Female
    }
}
