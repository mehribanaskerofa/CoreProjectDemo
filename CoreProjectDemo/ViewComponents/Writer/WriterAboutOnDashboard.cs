using BusinessLayer.Concrete;
using DataAccessLayer.SqlServer.Context;
using DataAccessLayer.SqlServer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjectDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard: ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EFWriterRepository());

        SqlServerContext context = new SqlServerContext();

        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            ViewBag.veri = username;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = writerManager.GetWriterById(writerID);
            return View(values);
        }
    }
}
