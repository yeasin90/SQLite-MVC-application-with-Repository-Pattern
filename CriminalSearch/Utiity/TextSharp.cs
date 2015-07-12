using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Web;
using CriminalSearch.Repository.Entity;

namespace CriminalSearch.Utility
{
    public class TextSharp : PdfGenerator
    {
        public override void Create(Criminal entity)
        {
            string basePath = Path.Combine(baseDirectory, "PDF", entity.ID.ToString() + "_" + entity.Name + ".pdf");

            FileStream fs = new FileStream(basePath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            document.Add(new Paragraph("Criminal Name : " + entity.Name));
            document.Add(new Paragraph("Criminal Nationality : " + entity.Nationality));
            document.Add(new Paragraph("Criminal Age : " + entity.Age));

            document.Close();
            writer.Close();
            fs.Close();
        }

        public override string OpenPdf(Criminal entity)
        {
            return Path.Combine(baseDirectory, "PDF", entity.ID.ToString() + "_" + entity.Name + ".pdf");
        }
    }
}
