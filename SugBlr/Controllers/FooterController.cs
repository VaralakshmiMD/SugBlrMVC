using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using SugBlr.Models;

namespace SugBlr.Controllers
{
    public class FooterController : Controller
    {
        // GET: Footer
        public ActionResult Index()
        {
            Footer footer = new Footer();
            Item datasource = Sitecore.Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
            footer.CopyrightText = datasource.Fields["Copyright Text"].Value;
            ImageField imageField = datasource.Fields["Logo"];
            if (imageField != null && imageField.MediaItem != null)
            {
                Sitecore.Data.Items.MediaItem image = new Sitecore.Data.Items.MediaItem(imageField.MediaItem);
                Sitecore.Links.UrlBuilders.MediaUrlBuilderOptions options = new Sitecore.Links.UrlBuilders.MediaUrlBuilderOptions();
                options.AlwaysIncludeServerUrl = true;
                options.AbsolutePath = false;
                footer.Logo = Sitecore.Resources.Media.MediaManager.GetMediaUrl(image, options);
            }
            return View(footer);
        }
    }
}