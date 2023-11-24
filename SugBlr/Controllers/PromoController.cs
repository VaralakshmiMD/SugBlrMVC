using Sitecore.Data.Fields;
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
    public class PromoController : Controller
    {
        // GET: Promo
        public ActionResult Index()
        {
            Promo promo = new Promo();

            Item datasource = Sitecore.Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
            promo.Title = datasource.Fields["Title"].Value;
            promo.Description = datasource.Fields["Description"].Value;
            ImageField imageField = datasource.Fields["Image"];
            if (imageField != null && imageField.MediaItem != null)
            {
                Sitecore.Data.Items.MediaItem image = new Sitecore.Data.Items.MediaItem(imageField.MediaItem);
                Sitecore.Links.UrlBuilders.MediaUrlBuilderOptions options = new Sitecore.Links.UrlBuilders.MediaUrlBuilderOptions();
                options.AlwaysIncludeServerUrl = true;
                options.AbsolutePath = false;
                promo.Image =Sitecore.Resources.Media.MediaManager.GetMediaUrl(image, options);
            }
            LinkField link = datasource.Fields["CTA Link"];
            promo.CTALink = link;
            if (link.IsInternal)
            {
                promo.URL = Sitecore.Links.LinkManager.GetItemUrl(link.TargetItem);
            }
            else
            {
                promo.URL = link.Url;
            }
            return View(promo);
        }
    }
}