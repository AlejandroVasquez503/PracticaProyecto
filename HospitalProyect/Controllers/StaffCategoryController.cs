using HospitalProyect.Models;
using HospitalProyect.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProyect.Controllers
{
    public class StaffCategoryController : Controller
    {
        private readonly StaffCategoryRepository _staffCategoryRepository;

        public StaffCategoryController(StaffCategoryRepository staffCategoryRepository)
        {
            _staffCategoryRepository = staffCategoryRepository;
        }

        // GET: StaffCategoryController
        public IActionResult Index()
        {
            var staffCategoryList = _staffCategoryRepository.GetAll();
            return View(staffCategoryList);
        }

        // GET: StaffCategoryController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StaffCategoryModel staffCategoryModel)
        {
            if (ModelState.IsValid)
            {
                _staffCategoryRepository.Add(staffCategoryModel);
                return RedirectToAction(nameof(Index));
            }
            return View(staffCategoryModel);
        }

        // GET: StaffCategoryController/Edit/5
        public IActionResult Edit(int id)
        {
            var staffCategory = _staffCategoryRepository.GetById(id);
            if (staffCategory == null) return NotFound();

            return View(staffCategory);
        }

        // POST: StaffCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StaffCategoryModel staffCategoryModel)
        {
            if (ModelState.IsValid)
            {
                _staffCategoryRepository.Update(staffCategoryModel);
                return RedirectToAction(nameof(Index));
            }
            return View(staffCategoryModel);
        }

        // POST: StaffCategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _staffCategoryRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
