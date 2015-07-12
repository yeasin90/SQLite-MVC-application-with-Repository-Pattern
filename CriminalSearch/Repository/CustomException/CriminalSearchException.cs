using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalSearch.Repository.CustomException
{
    public class CriminalSearchException : Exception
    {
        public CriminalSearchException(string message)
            : base(message)
        {
        }
    }
}
