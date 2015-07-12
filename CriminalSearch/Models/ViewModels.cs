using CriminalSearch.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriminalSearch.Models
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class CriminalSearchViewModel
    {
        public SearchType SearchBy { get; set; }
        public double[] Range { get; set; }
        public string SingleInput { get; set; }
        public List<Criminal> Criminals { get; set; }

        public CriminalSearchViewModel()
        {
            Criminals = new List<Criminal>();
        }
    }
}