using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Razor;
using NewsDemo.Models;
using Newtonsoft.Json.Linq;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;


namespace NewsDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(NewsFeed news)
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";

            var newsApiClient = new NewsApiClient("cb0c01ef96964a42a903295d3fce7aa0");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "Google",
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = new DateTime(2018, 1, 25)
            });

            IList<NewsFeed> articleList = new List<NewsFeed>();

            if (articlesResponse.Status == Statuses.Ok)
            {
                // total results found
                Console.WriteLine(articlesResponse.TotalResults);

            }

            // here's the first 20
            foreach (var article in articlesResponse.Articles)
            {

                NewsFeed LatestNews = new NewsFeed();
                {
                    // title
                    LatestNews.Title = article.Title;
                    // author
                    LatestNews.Author = article.Author;
                    // description
                    LatestNews.Description = article.Description;
                    // url
                    LatestNews.Url = article.Url;
                    // image
                    LatestNews.UrlToImage = article.UrlToImage;
                    // published at
                    LatestNews.PublishedAt = article.PublishedAt;

                };

                articleList.Add(LatestNews);

                var list = new List<NewsFeed>(articleList);

                news.NewsList = list;
            }

            return View(news);
        }


    }


}
