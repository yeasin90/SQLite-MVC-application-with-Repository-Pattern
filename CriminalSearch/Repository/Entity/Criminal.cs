using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalSearch.Repository.Entity
{
    [Serializable]
    public class Criminal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Gender Sex { get; set; }
        public double Height { get; set; }
        public string Nationality { get; set; }
    }
}
