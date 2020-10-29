using System;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class CongViecController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string View(int id)
        {
            CongViec congViec = new CongViec();
            congViec.ID = id;
            congViec.Name = "Hello there!!!";

            var result = $"{congViec.ID} | {congViec.Name}";

            return result;
        }
    }
}