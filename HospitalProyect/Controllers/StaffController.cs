using HospitalProyect.Models;
using HospitalProyect.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalProyect.Controllers
{
    public class StaffController : Controller
    {
        private readonly StaffRepository _staffRepository;
        private readonly StaffCategoryRepository _staffCategoryRepository;
        private readonly SpecialtyRepository _specialtyRepository;

        public StaffController(StaffRepository staffRepository, StaffCategoryRepository staffCategoryRepository, SpecialtyRepository specialtyRepository)
        {
            _staffRepository = staffRepository;
            _staffCategoryRepository = staffCategoryRepository;
            _specialtyRepository = specialtyRepository;
        }

        // GET: StaffController
        public IActionResult Index()
        {
            var staffList = _staffRepository.GetAll();
            return View(staffList);
        }

        // GET: StaffController/Create
        public IActionResult Create()
        {
            var specialties = _specialtyRepository.GetAll();
            var staffCategories = _staffCategoryRepository.GetAll();

            ViewBag.Specialties = new SelectList(specialties, nameof(SpecialtyModel.Id), nameof(SpecialtyModel.Name));
            ViewBag.StaffCategories = new SelectList(staffCategories, nameof(StaffCategoryModel.Id), nameof(StaffCategoryModel.Name));
            return View();
        }

        // POST: StaffController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StaffModel staff)
        {
            if (!ModelState.IsValid)
            {
                _staffRepository.Add(staff);
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // GET: StaffController/Edit/5
        public IActionResult Edit(int id)
        {
            var staff = _staffRepository.GetById(id);
            if (staff == null) return NotFound();

            var specialties = _specialtyRepository.GetAll();
            var staffCategories = _staffCategoryRepository.GetAll();

            ViewBag.Specialties = new SelectList(specialties, nameof(SpecialtyModel.Id), nameof(SpecialtyModel.Name), staff.SpecialtyId);
            ViewBag.StaffCategories = new SelectList(staffCategories, nameof(StaffCategoryModel.Id), nameof(StaffCategoryModel.Name), staff.StaffCategoryId);

            return View(staff);
        }

        // POST: StaffController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StaffModel staff)
        {
            if (!ModelState.IsValid)
            {
                _staffRepository.Update(staff);
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        public IActionResult Delete(int id)
        {
            var staff = _staffRepository.GetById(id);
            if (staff == null) return NotFound();
            return View(staff);
        }

        // POST: StaffController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(StaffModel staffModel)
        {
            _staffRepository.Delete(staffModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
