using LuyenDe_PE_SU23.Model;

namespace LuyenDe_PE_SU23.DataAccess.DAO
{
    public class EmployeeDAO
    {

        readonly PE_PRN231_Sum23B5Context _context = new PE_PRN231_Sum23B5Context();

        public EmployeeDAO(){}
        public EmployeeDAO(PE_PRN231_Sum23B5Context context)
        {
            _context = context;
        }
        public void DeleteEmployee(int id)
        {
            Employee employee = _context.Employees.FirstOrDefault(x => x.EmployeeId == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

    }
}
