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
    public class CardsController : Controller
    {
        // GET: Cards
        public ActionResult Index()
        {
            Cards cards = new Cards();
            cards.CardList = new List<Card>();
            Item datasource = Sitecore.Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
            
            MultilistField multiselectField = datasource.Fields["Card List"];
            Sitecore.Data.Items.Item[] items = multiselectField.GetItems();
            //Iterate through each item
            if (items != null && items.Length > 0)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    Card card = new Card();
                    Item cardItem = items[i];
                    ImageField imageField = cardItem.Fields["Image"];
                    if (imageField != null && imageField.MediaItem != null)
                    {
                        Sitecore.Data.Items.MediaItem image = new Sitecore.Data.Items.MediaItem(imageField.MediaItem);
                        Sitecore.Links.UrlBuilders.MediaUrlBuilderOptions options = new Sitecore.Links.UrlBuilders.MediaUrlBuilderOptions();
                        options.AlwaysIncludeServerUrl = true;
                        options.AbsolutePath = false;
                        card.Image = Sitecore.Resources.Media.MediaManager.GetMediaUrl(image, options);
                    }
                    card.Name = cardItem.Fields["Name"].Value;
                    card.CompanyName = cardItem.Fields["Company Name"].Value;
                    card.Description = cardItem.Fields["Description"].Value;
                    card.Topic = cardItem.Fields["Topic"].Value;
                    cards.CardList.Add(card);
                }
            }
            return View(cards);
        }
    }
}