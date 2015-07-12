using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalSearch.Repository.CustomException
{
    public class MembershipException : Exception
    {
        public MembershipException(string message)
            : base(message)
        {
        }
    }
}
