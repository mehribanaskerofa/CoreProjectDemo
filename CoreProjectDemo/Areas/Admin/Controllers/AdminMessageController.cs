using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using DataAccessLayer.SqlServer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjectDemo.Areas.Admin.Controllers
{
        [Area("Admin")]
        public class AdminMessageController : Controller
        {
            Message2Manager mm = new Message2Manager(new EFMessage2Repository());
            SqlServerContext c = new SqlServerContext();
            private UserManager<AppUser> _userManager;

        public AdminMessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Inbox()
            {
                var username = User.Identity.Name;
                var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
                var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
                var values = mm.GetInboxListByWriter(writerID);
                //if (values.Count() > 10)
                //{
                //    values = values.TakeLast(10).ToList();
                //}
                return View(values);
            }
            public IActionResult SendBox()
            {
                var username = User.Identity.Name;
                var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
                var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
                var values = mm.GetSendBoxListByWriter(writerID);
                //if (values.Count() > 10)
                //{
                //    values = values.TakeLast(10).ToList();
                //}
                return View(values);
            }

        //[HttpGet]
        //public IActionResult ComposeMessage()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult ComposeMessage(Message2 message)
        //{
        //    var username = User.Identity.Name;
        //    var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
        //    var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
        //    message.SenderID = writerID;
        //    message.ReceiverID = 2;
        //    message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //    message.MessageStatus = true;
        //    mm.TAdd(message);
        //    return RedirectToAction("SendBox");
        //}

        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View(Tuple.Create<Message2, AppUser>(new Message2(), new AppUser()));
        }
        [HttpPost]
        public async Task<IActionResult> ComposeMessage([Bind(Prefix = "Item1")] Message2 message, [Bind(Prefix = "Item2")] AppUser writer)
        {
            var sender = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiver = await _userManager.FindByEmailAsync(writer.Email);
            message.SenderID = sender.Id;
            message.ReceiverID = receiver.Id;
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.MessageStatus = true;
            mm.TAdd(message);
            return RedirectToAction("Sendbox");
        }
    }
}
