using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using SugBlr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SugBlr.Controllers
{
    public class TitleBlockController : Controller
    {
        // GET: TitleBlock
        public ActionResult Index()
        {
            TitleBlock titleBlock = new TitleBlock();
            
            Item datasource = Sitecore.Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
            titleBlock.titleBlock = datasource.Fields["Title Block"].Value;
            return View(titleBlock);
        }
    }
}