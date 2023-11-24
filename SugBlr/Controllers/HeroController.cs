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
    public class HeroController : Controller
    {
        // GET: Hero
        [Obsolete]
        public ActionResult Index()
        {
            Hero hero = new Hero();

            Item datasource = Sitecore.Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
            hero.Title = datasource.Fields["Title"].Value;
            hero.SubTitle = datasource.Fields["Sub Title"].Value;
            hero.Description = datasource.Fields["Description"].Value;
            ImageField imageField = datasource.Fields["Background Image"];
            if (imageField != null && imageField.MediaItem != null)
            {
                Sitecore.Data.Items.MediaItem image = new Sitecore.Data.Items.MediaItem(imageField.MediaItem);
                Sitecore.Links.UrlBuilders.MediaUrlBuilderOptions options = new Sitecore.Links.UrlBuilders.MediaUrlBuilderOptions();
                options.AlwaysIncludeServerUrl = true;
                options.AbsolutePath = false;
                hero.BackgroundImage = Sitecore.Resources.Media.MediaManager.GetMediaUrl(image, options);
            }
            LinkField link = datasource.Fields["CTA Link"];
            hero.CTALink = link;
            if (link.IsInternal)
            {
                hero.URL = Sitecore.Links.LinkManager.GetItemUrl(link.TargetItem);
            }
            else
            {
                hero.URL = link.Url;
            }
            
            
            return View(hero);
        }
    }
}