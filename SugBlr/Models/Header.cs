using Sitecore.Data.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SugBlr.Models
{
    public class Header
    {
        public string Logo { get; set; }
        public List<Links> Links { get; set; }
    }
}