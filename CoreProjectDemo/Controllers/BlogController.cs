﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreProjectDemo.Models;
using DataAccessLayer.SqlServer.Context;
using DataAccessLayer.SqlServer.Repositories;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjectDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EFBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());
        SqlServerContext context = new SqlServerContext();

        [AllowAnonymous]

        public IActionResult Index()
        {
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }

        [AllowAnonymous]

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = blogManager.GetBlogByID(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = blogManager.GetListWithCategoryByWriterBm(writerID);

            return View(values);
        }
        public void GetCategoryList()
        {
            List<SelectListItem> categoryvalues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.category = categoryvalues;
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            GetCategoryList();
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(BlogModel blogModel)//Blog blog, IFormFile image)
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
       

            Blog blog = new Blog()
            {
                BlogContent = blogModel.BlogContent,
                BlogTitle=blogModel.BlogTitle       
            };
            
            if (blogModel.BlogImage != null)
            {
                var extension = Path.GetExtension(blogModel.BlogImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                blogModel.BlogImage.CopyTo(stream);
                blog.BlogImage = newimagename;
                blog.BlogThumbnailImage = newimagename;
            }

            //blog.BlogImage = "f7ef54a1-5bf5-4e5a-98ed-15ad4fec47a3.png";
            //blog.BlogThumbnailImage = "f7ef54a1-5bf5-4e5a-98ed-15ad4fec47a3.png";

            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(blog);
            if (results.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = writerID;
                blogManager.TAdd(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            GetCategoryList();
            return View();
        }
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = blogManager.TGetById(id);
            blogManager.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {//59
            var blogvalue = blogManager.TGetById(id);
            GetCategoryList();
            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            GetCategoryList();
            var value = blogManager.TGetById(blog.BlogID);
            blog.WriterID = writerID;
            blog.BlogCreateDate = value.BlogCreateDate;
            blog.BlogStatus = true;
            blogManager.TUpdate(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
