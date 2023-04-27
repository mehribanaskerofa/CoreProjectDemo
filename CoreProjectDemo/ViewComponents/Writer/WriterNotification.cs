using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjectDemo.ViewComponents.Writer
{
    public class WriterNotification:ViewComponent
    {
        NotificationManager nm = new NotificationManager(new EFNotificationRepository());

        public IViewComponentResult Invoke()
        {
            var values = nm.GetList(x => x.NotificationStatus == true && x.NotificationStatus == true);
            if (values.Count() > 3)
            {
                values = values.Take(5).ToList();
            }
            return View(values);
        }
    }
}
