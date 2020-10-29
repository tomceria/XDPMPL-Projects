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

        public IActionResult Edit(int id)
        {
            CongViec congViec = new CongViec();
            congViec.ID = id;
            congViec.Name = "Hello there!!!";

            ViewData["CongViecID"] = congViec.ID;
            ViewData["CongViecName"] = congViec.Name;

            return View();
        }
    }
}