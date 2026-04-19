using HospitalProyect.Models;
using HospitalProyect.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProyect.Controllers
{
    [Authorize]
    public class SpecialtyController : Controller
    {
        private readonly SpecialtyRepository _specialtyRepository;

        public SpecialtyController(SpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        // GET: SpecialtyController
        public IActionResult Index()
        {
            var specialtyList = _specialtyRepository.GetAll();
            return View(specialtyList);
        }

        // GET: SpecialtyController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpecialtyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SpecialtyModel specialtyModel)
        {
            if (!ModelState.IsValid)
            {
                _specialtyRepository.Add(specialtyModel);
                return RedirectToAction(nameof(Index));
            }
            return View(specialtyModel);
        }

        // GET: SpecialtyController/Edit/5
        public IActionResult Edit(int id)
        {
            var specialty = _specialtyRepository.GetById(id);
            if (specialty == null) return NotFound();

            return View(specialty);
        }

        // POST: SpecialtyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SpecialtyModel specialtyModel)
        {
            if (!ModelState.IsValid)
            {
                _specialtyRepository.Update(specialtyModel);
                return RedirectToAction(nameof(Index));
            }
            return View(specialtyModel);
        }

        public IActionResult Delete(int id)
        {
            var specialty = _specialtyRepository.GetById(id);
            if (specialty == null) return NotFound();
            return View(specialty);
        }

        // POST: SpecialtyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(SpecialtyModel specialtyModel)
        {
            _specialtyRepository.Delete(specialtyModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
