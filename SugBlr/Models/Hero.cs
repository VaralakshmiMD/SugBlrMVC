using Sitecore.Data.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SugBlr.Models
{
    public class Hero
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string BackgroundImage { get; set; }
        public LinkField CTALink { get; set; }
        public string URL { get; set; }
    }
}