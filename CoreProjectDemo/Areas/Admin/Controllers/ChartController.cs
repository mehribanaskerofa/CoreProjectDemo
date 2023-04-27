using CoreProjectDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjectDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryModel> models = new List<CategoryModel>();

            models.Add(new CategoryModel { 
                categorycount=2,
                categoryname="a"
            });
            models.Add(new CategoryModel
            {
                categorycount = 3,
                categoryname = "b"
            });
            models.Add(new CategoryModel
            {
                categorycount = 4,
                categoryname = "c"
            });
            return Json(new {jsonList=models });
        }

    }
}
