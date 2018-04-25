using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsDemo.Models
{
    public class NewsFeed
    {
        public List<NewsFeed> NewsList { get; set; }
        public string Id { set; get; }
        public string Name { set; get; }
        public string Author { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public string Url { set; get; }
        public string UrlToImage { set; get; }
        public DateTime? PublishedAt { set; get; }
    }

}