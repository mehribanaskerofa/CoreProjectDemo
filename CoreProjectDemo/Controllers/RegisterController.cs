using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.SqlServer.Repositories;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjectDemo.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EFWriterRepository());
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Cities = GetCityList();
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer writer, string PasswordAgain, string cities)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(writer);
            if (results.IsValid && writer.WriterPassword == PasswordAgain)
            {
                writer.WriterStatus = true;
                writer.WriterAbout = "Deneme Test";
                writerManager.TAdd(writer);
                return RedirectToAction("Index", "Blog");
            }
            else if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            else
            {
                ModelState.AddModelError("WriterPassword", "The Passwords You Entered Do Not Match! Please try again");
            }
            return View();
        }

        public List<SelectListItem> GetCityList()
        {
            List<SelectListItem> adminrole = (from x in GetCity()
                                              select new SelectListItem
                                              {
                                                  Text = x,
                                                  Value = x
                                              }).ToList();
            return adminrole;
        }
        public List<string> GetCity()
        {
            String[] CitiesArray = new String[] {"Baku", "Shemkir", "Gence" };
            return new List<string>(CitiesArray);
        }
    }
}
