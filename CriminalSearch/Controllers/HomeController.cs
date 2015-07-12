using CriminalSearch.Models;
using CriminalSearch.Repository.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharpCriminalSearch.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly HomeModel _homeModel;
        private NotyMessage _notyMessage;

        public HomeController(HomeModel homeModel)
        {
            _homeModel = homeModel;
        }

        public ActionResult Index()
        {
            CriminalSearchViewModel viewmodel = new CriminalSearchViewModel();
            return View(viewmodel);
        }

        public ActionResult ShowCriminalRecords(CriminalSearchViewModel viewmodel)
        {
            try
            {
                viewmodel.Criminals = _homeModel.PopulateSearchList(viewmodel).ToList();
                return View(viewmodel);
            }
            catch (CriminalSearchException ex)
            {
                _notyMessage = new NotyMessage { ResponseMessage = ex.Message, ResponseType = NotyType.error };
            }
            catch (Exception ex)
            {
                _notyMessage = new NotyMessage { ResponseMessage = SystemMessage.GeneralErrorMessage, ResponseType = NotyType.error };
            }

            TempData["NotyMessage"] = _notyMessage;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ShowPDF(int id)
        {
            string path = _homeModel.GeneratePDF(id);
            return File(path, "application/pdf");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
