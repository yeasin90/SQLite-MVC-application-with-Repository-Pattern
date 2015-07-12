using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using CriminalSearch.Repository.Repository;
using CriminalSearch.Utility;

namespace CriminalSearch.Repository
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>();
            Bind<ICriminalRepository>().To<CriminalRepository>();
        }
    }
}
