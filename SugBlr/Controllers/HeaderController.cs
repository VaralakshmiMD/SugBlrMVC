using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using SugBlr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SugBlr.Controllers
{
    public class HeaderController : Controller
    {
        // GET: Header
        public ActionResult Index()
        {
            Header header = new Header();
            header.Links = new List<Links>();
            Item datasource = Sitecore.Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
            ImageField imageField = datasource.Fields["Logo"];
            if (imageField != null && imageField.MediaItem != null)
            {
                Sitecore.Data.Items.MediaItem image = new Sitecore.Data.Items.MediaItem(imageField.MediaItem);
                Sitecore.Links.UrlBuilders.MediaUrlBuilderOptions options = new Sitecore.Links.UrlBuilders.MediaUrlBuilderOptions();
                options.AlwaysIncludeServerUrl = true;
                options.AbsolutePath = false;
                header.Logo = Sitecore.Resources.Media.MediaManager.GetMediaUrl(image,options);
            }
            MultilistField multiselectField = datasource.Fields["Links"];
            Sitecore.Data.Items.Item[] items = multiselectField.GetItems();
            //Iterate through each item
            if (items != null && items.Length > 0)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    
                    Links links = new Links();
                    Sitecore.Data.Items.Item linkItem = items[i];
                    LinkField link = linkItem.Fields["Link"];
                    links.link = link;
                    if (link.IsInternal)
                    {
                        //datasource.Editing.BeginEdit();
                        //link.Clear();
                        //link.LinkType = "internal";
                        //Sitecore.Links.UrlOptions urlOptions = Sitecore.Links.LinkManager.GetDefaultUrlOptions();
                        //urlOptions.AlwaysIncludeServerUrl = false;
                        //link.Url = Sitecore.Links.LinkManager.GetItemUrl(link.TargetItem, urlOptions);
                        //link.TargetID = link.TargetItem.ID;
                        //datasource.Editing.EndEdit();
                        links.URL = Sitecore.Links.LinkManager.GetItemUrl(link.TargetItem);
                    }
                    else
                    {
                        links.URL = link.Url;
                    }
                    header.Links.Add(links);

                }
            }
            return View(header);
        }
    }
}