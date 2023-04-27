using DataAccessLayer.SqlServer.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjectDemo.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
       // Message2Manager messageManager = new Message2Manager(new EfMessage2Repository());
        SqlServerContext context = new SqlServerContext();

        public IViewComponentResult Invoke()
        {
            //var username = User.Identity.Name;
            //var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //var writerID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            //var values = messageManager.GetInboxListByWriter(writerID);
            //if (values.Count() > 3)
            //{
            //    values = values.TakeLast(3).ToList();
            //}
            //return View(values);
            return View();
        }
    }
}
