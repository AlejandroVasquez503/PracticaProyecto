using HospitalProyect.Data;
using HospitalProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalProyect.Repositories
{
    public class StaffRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StaffRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public List<StaffModel> GetAll()
        {
            return _applicationDbContext.staffModel
                .Include(s => s.StaffCategory)
                .Include(s => s.Specialty)
                .ToList();
        }

        public StaffModel GetById(int id)
        {
            return _applicationDbContext.staffModel
                .Include(s => s.StaffCategory)
                .Include(s => s.Specialty)
                .FirstOrDefault(sm => sm.Id == id);
        }
        public void Add(StaffModel StaffModel)
        {
            _applicationDbContext.staffModel.Add(StaffModel);
            _applicationDbContext.SaveChanges();
        }

        public void Update(StaffModel staffModel)
        {
            _applicationDbContext.staffModel.Update(staffModel);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var staff = _applicationDbContext.staffModel.Find(id);

            if (staff != null)
            {
                _applicationDbContext.staffModel.Remove(staff);
                _applicationDbContext.SaveChanges();
            }
        }

    }
}
