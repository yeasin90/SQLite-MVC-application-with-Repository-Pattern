using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using CriminalSearch.Utility;

namespace CriminalSearch.Utiity
{
    public class UtilityModule : NinjectModule
    {
        public override void Load()
        {
            Bind<SqLiteHelper>().ToSelf().WithConstructorArgument("dataSource", "MyTestDb.sqlite");
            Bind<PdfGenerator>().To<TextSharp>().Named("TextSharp");
            Bind<InputValidator>().ToSelf();
        }
    }
}