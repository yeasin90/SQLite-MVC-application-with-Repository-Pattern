using CriminalSearch.Repository;
using CriminalSearch.Repository.Entity;
using CriminalSearch.Repository.Repository;
using CriminalSearch.Security;
using CriminalSearch.Utility;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Security;

namespace CriminalSearch.Models
{
    public class AccountModel
    {
        private readonly MembershipService _membershipService;
        private readonly ICriminalRepository _criminalRepository;
        private readonly SqLiteHelper _sqliteHelper;

        public AccountModel(MembershipService membershipService, ICriminalRepository criminalRepository, SqLiteHelper sqliteHelper)
        {
            _membershipService = membershipService;
            _criminalRepository = criminalRepository;
            _sqliteHelper = sqliteHelper;

            //_sqliteHelper.InitializeData();// Just a dummy call to populate DB
        }

        public void CreteUser(RegisterViewModel viewmodel)
        {
            User entity = new User { Email = viewmodel.Email, Username = viewmodel.UserName, Password = viewmodel.Password };
            _membershipService.CreteUser(entity);
        }

        public bool Login(LoginViewModel viewmodel)
        {
            return _membershipService.Login(viewmodel.UserName, viewmodel.Password);
        }
    }
}
