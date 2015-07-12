using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalSearch.Repository.Entity
{
    [Serializable]
    public class CriminalSearchItem
    {
        public double From { get; set; }
        public double To { get; set; }
        public string SingleInput { get; set; }
        public Gender Sex { get; set; }
    }
}
