using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawWebSite.Common
{
    public class ReturnModel<T>
    {
        public bool Is_Error { get; set; }
        public string Message_Header { get; set; }
        public string Message_Content { get; set; }
        public List<T> Model { get; set; }
    }
}