using CriminalSearch.Repository.Entity;
using CriminalSearch.Repository.Repository;
using CriminalSearch.Security;
using CriminalSearch.Utility;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CriminalSearch.Models
{
    public class HomeModel
    {
        private readonly ICriminalRepository _criminalRepository;
        private readonly PdfGenerator _pdfGenerator;

        public HomeModel(ICriminalRepository criminalRepository, [Named("TextSharp")]PdfGenerator pdfGenerator)
        {
            _criminalRepository = criminalRepository;
            _pdfGenerator = pdfGenerator;
        }

        public IList<Criminal> PopulateSearchList(CriminalSearchViewModel viewmodel)
        {
            CriminalSearchItem searchitem = new CriminalSearchItem();

            if (viewmodel.SearchBy == SearchType.Name || viewmodel.SearchBy == SearchType.Nationality)
            {
                searchitem.SingleInput = viewmodel.SingleInput;
            }
            else
            {
                searchitem.From = viewmodel.Range[0];
                searchitem.To = viewmodel.Range[1];
            }

            return _criminalRepository.GetCriminalsByType(viewmodel.SearchBy, searchitem);
        }

        public string GeneratePDF(int criminlID)
        {
            Criminal criminal = _criminalRepository.Get(criminlID);
            if (!_pdfGenerator.HasPDF(criminal))
                _pdfGenerator.Create(criminal);

            return _pdfGenerator.OpenPdf(criminal);
        }
    }
}