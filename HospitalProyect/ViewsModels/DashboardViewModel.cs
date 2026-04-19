namespace HospitalProyect.ViewsModels
{
    public class DashboardViewModel
    {
        public int TotalStaff { get; set; }
        public int ActiveStaff { get; set; }

        public int InactiveStaff {  get; set; }

        public Dictionary<string, int> StaffByCategory { get; set; } = new Dictionary<string, int>();
    }
}
