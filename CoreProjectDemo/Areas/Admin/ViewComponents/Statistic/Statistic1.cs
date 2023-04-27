using BusinessLayer.Concrete;
using DataAccessLayer.SqlServer.Context;
using DataAccessLayer.SqlServer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace CoreProjectDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EFBlogRepository());
        SqlServerContext context = new SqlServerContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.blogCount = blogManager.GetList().Count;
            ViewBag.contactCount = context.Contacts.Count();
            ViewBag.commentCount = context.Comments.Count();


            string apiKey = "b535d77ec67015546740bd5439a80117";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=azerbaijan&mode=xml&lang=tr&units=metric&appid=" + apiKey;
            XDocument document = XDocument.Load(connection);
            ViewBag.weather = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
