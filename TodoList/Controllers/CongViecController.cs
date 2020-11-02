using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;
using TodoList.Services.IService;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
    public class CongViecController : Controller
    {
        private readonly ICongViecService _congViecService;

        public CongViecController(ICongViecService congViecService)
        {
            _congViecService = congViecService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _congViecService.GetAllCongViecs());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            // Get CongViec
            if (id == null)
            {
                return NotFound();
            }

            var congViec = await _congViecService.GetOneCongViec((int) id);
            if (congViec == null)
            {
                return NotFound();
            }

            // Constructs VietModel
            CongViecEditVm viewModel = new CongViecEditVm();
            viewModel.CongViec = congViec;

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name)
        {
            var congViec = await _congViecService.CreateCongViec(name);
            _congViecService.AddCongViec(congViec);
            await _congViecService.Save();

            return RedirectToAction("Edit", new {id = congViec.ID});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,StartDate,EndDate,TrangThai,Privacy,NhanVienID")]
            CongViec congViec)
        {
            if (id != congViec.ID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(
                    new CongViecEditVm { CongViec = congViec }
                );
            }

            _congViecService.UpdateCongViec(congViec);
            await _congViecService.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            CongViec congViec = await _congViecService.GetOneCongViec(id);
            if (congViec == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return RedirectToAction("Edit", new {id = id});

            _congViecService.DeleteCongViec(congViec);
            await _congViecService.Save();

            return RedirectToAction("Index");
        }
    }
}