using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriminalSearch.Models
{
    public class NotyMessage
    {
        public string ResponseMessage { get; set; }
        public NotyType ResponseType { get; set; }
    }

    public enum NotyType
    {
        success,
        error,
        warning
    }
}