using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using CriminalSearch.Utility;

namespace CriminalSearch.Security
{
    public class SecurityModule : NinjectModule
    {
        public override void Load()
        {
            Bind<MembershipService>().ToSelf();
        }
    }
}
