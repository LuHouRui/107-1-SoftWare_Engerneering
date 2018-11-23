using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Insert_DataBase_Example.DataBase;
using Insert_DataBase_Example.Models;

namespace WebApplication1.Controllers
{
    public class OpenDataController : Controller
    {
        public IActionResult Index()
        {
            OpenDataDbContext db = new OpenDataDbContext();
            List<OpenData> model = db.OpenData.ToList();
            return View(model);
        }
    }
}