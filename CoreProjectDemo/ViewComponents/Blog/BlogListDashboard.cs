﻿using BusinessLayer.Concrete;
using DataAccessLayer.SqlServer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjectDemo.ViewComponents.Blog
{
    public class BlogListDashboard:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EFBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }
    }
}
