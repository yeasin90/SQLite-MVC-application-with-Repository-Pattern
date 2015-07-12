using CriminalSearch.Repository.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalSearch.Utility
{
    public abstract class PdfGenerator
    {
        protected readonly string baseDirectory;
        public abstract void Create(Criminal entity);
        public abstract string OpenPdf(Criminal entity);

        public PdfGenerator()
        {
            var appDomain = System.AppDomain.CurrentDomain;
            baseDirectory = appDomain.BaseDirectory;//appDomain.RelativeSearchPath ?? appDomain.BaseDirectory;
        }

        public bool HasPDF(Criminal entity)
        {
            string basePath = Path.Combine(baseDirectory, "PDF", entity.ID.ToString() + "_" + entity.Name);
            try
            {
                FileStream fs = new FileStream(basePath, FileMode.Open, FileAccess.Read, FileShare.None);
                return true;
            }
            catch (FileNotFoundException ex)
            {
                return false;
            }
        }
    }
}
