using BusinessLayer.Concrete;
using DataAccessLayer.SqlServer.Context;
using DataAccessLayer.SqlServer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjectDemo.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager blogManager = new BlogManager(new EFBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());
        SqlServerContext context = new SqlServerContext();

        public IActionResult Index()
        {
            //var username = User.Identity.Name;
            //var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //var writerid = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            //ViewBag.BlogCount = blogManager.GetList(x => x.BlogStatus == true).Count();
            //ViewBag.OurBlogCount = context.Blogs.Where(x => x.WriterID == writerid).Count();
            //ViewBag.CategoryCount = categoryManager.GetList().Count();
            return View();
        }
    }
}
