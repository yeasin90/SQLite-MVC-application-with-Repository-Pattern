using CriminalSearch.Models;
using CriminalSearch.Repository.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CSharpCriminalSearch.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly AccountModel _accountModel;
        private NotyMessage _notyMessage;

        public AccountController(AccountModel accountModel)
        {
            _accountModel = accountModel;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            LoginViewModel viewmodel = new LoginViewModel();
            return View(viewmodel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel viewmodel, string returnUrl)
        {
            try
            {
                if (_accountModel.Login(viewmodel))
                {
                    _notyMessage = new NotyMessage { ResponseMessage = "Logged In successfull.", ResponseType = NotyType.success };
                    TempData["NotyMessage"] = _notyMessage;
                    FormsAuthentication.SetAuthCookie(viewmodel.UserName, viewmodel.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    _notyMessage = new NotyMessage { ResponseMessage = "User is not found.", ResponseType = NotyType.error };
                    TempData["NotyMessage"] = _notyMessage;
                    return View(viewmodel);
                }
            }
            catch (MembershipException ex)
            {
                _notyMessage = new NotyMessage { ResponseMessage = ex.Message, ResponseType = NotyType.error };
            }
            catch (Exception ex)
            {
                _notyMessage = new NotyMessage { ResponseMessage = SystemMessage.GeneralErrorMessage, ResponseType = NotyType.error };
            }

            TempData["NotyMessage"] = _notyMessage;
            return View(viewmodel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            RegisterViewModel viewmodel = new RegisterViewModel();
            return View(viewmodel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel viewmodel)
        {
            try
            {
                _accountModel.CreteUser(viewmodel);
                _notyMessage = new NotyMessage { ResponseMessage = "User has been registered.", ResponseType = NotyType.success };
            }
            catch (MembershipException ex)
            {
                _notyMessage = new NotyMessage { ResponseMessage = ex.Message, ResponseType = NotyType.error };
            }
            catch (Exception ex)
            {
                _notyMessage = new NotyMessage { ResponseMessage = SystemMessage.GeneralErrorMessage, ResponseType = NotyType.error };
            }

            TempData["NotyMessage"] = _notyMessage;
            return View(viewmodel);
        }

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion
    }
}
