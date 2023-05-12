using ClosedXML.Excel;
using CoreProjectDemo.Areas.Admin.Models;
using DataAccessLayer.SqlServer.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjectDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook=new XLWorkbook()){
                var worksheet = workbook.Worksheets.Add("Blog List");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Name";

                int RowCount = 2;
                foreach(var item in GetBlogList()){
                    worksheet.Cell(RowCount, 1).Value = item.ID;
                    worksheet.Cell(RowCount, 2).Value = item.Name;
                    RowCount++;
                }

                using(var stream=new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> bM = new List<BlogModel>
            {
                new BlogModel{ID=1,Name="blog1"},
                new BlogModel{ID=2,Name="blog2"}
            };
            return bM;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }


        //dynamic

        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog List");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Name";

                int RowCount = 2;
                foreach (var item in GetBlogTitleList())
                {
                    worksheet.Cell(RowCount, 1).Value = item.ID;
                    worksheet.Cell(RowCount, 2).Value = item.Name;
                    RowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    var fileName ="calisma_"+ Guid.NewGuid().ToString().Replace("-", "")+DateTime.Now.Ticks.ToString();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName+".xlsx");
                }
            }
        }
        public List<BlogModel2> GetBlogTitleList()
        {
            List<BlogModel2> bM = new List<BlogModel2>();
            using (var context =new SqlServerContext())
            {
                bM = context.Blogs.Select(x =>
                    new BlogModel2
                    {
                        ID = x.BlogID,
                        Name = x.BlogTitle
                    }
                ).ToList();
            }
            
            return bM;
        }
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
