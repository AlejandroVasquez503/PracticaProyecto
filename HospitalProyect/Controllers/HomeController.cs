using HospitalProyect.Models;
using HospitalProyect.Repositories;
using HospitalProyect.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HospitalProyect.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly DashboardRepository _dashboardRepository;

        public HomeController(DashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public IActionResult Index()
        {
            ViewBag.userName = User.Identity.Name;
            DashboardViewModel metrics = _dashboardRepository.GetDashboardMetrics();
            return View(metrics);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
