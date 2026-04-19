using HospitalProyect.Data;
using HospitalProyect.ViewsModels;

namespace HospitalProyect.Repositories
{
    public class DashboardRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DashboardRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public DashboardViewModel GetDashboardMetrics()
        {
            var model = new DashboardViewModel();

            model.TotalStaff = _applicationDbContext.staffModel.Count();
            model.ActiveStaff = _applicationDbContext.staffModel.Count(s => s.IsActive);
            model.InactiveStaff = model.TotalStaff - model.ActiveStaff;

            var categoryStats = _applicationDbContext.staffModel
                .Where(s => s.StaffCategory != null)
                .GroupBy(s => s.StaffCategory.Name)
                .Select(g => new { CategoryName = g.Key, Count = g.Count() })
                .ToList();
            foreach (var stat in categoryStats)
            {
                model.StaffByCategory.Add(stat.CategoryName, stat.Count);
            }

            return model;
        }

    }
}
