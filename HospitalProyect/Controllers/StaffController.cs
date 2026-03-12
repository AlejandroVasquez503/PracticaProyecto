using HospitalProyect.Models;
using HospitalProyect.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProyect.Controllers
{
    public class StaffController : Controller
    {
        private readonly StaffRepository _staffRepository;

        public StaffController(StaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
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
            return View();
        }

        // POST: StaffController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StaffModel staff)
        {
            if (ModelState.IsValid)
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

            return View(staff);
        }

        // POST: StaffController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StaffModel staff)
        {
            if (ModelState.IsValid)
            {
                _staffRepository.Update(staff);
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // POST: StaffController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _staffRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
