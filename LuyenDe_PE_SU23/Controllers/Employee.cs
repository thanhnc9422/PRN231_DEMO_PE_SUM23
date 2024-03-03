using LuyenDe_PE_SU23.DataAccess.DAO;
using LuyenDe_PE_SU23.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LuyenDe_PE_SU23.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class Employee : ControllerBase
    {
        readonly PE_PRN231_Sum23B5Context _context;
        public Employee(PE_PRN231_Sum23B5Context context)
        {
            _context = context;
        }
        private EmployeeDAO employeeDAO = new EmployeeDAO();
        [HttpPost("Delete/{EmployeeId}")]
        public ActionResult<IEnumerable<Model.Employee>> DeleteEmployee(int EmployeeId)
        {
            var orderDetails = _context.OrderDetails.Include(x => x.Order).Where(x => x.Order.EmployeeId == EmployeeId).ToList();
            if (orderDetails.Count > 0)
            {
                _context.OrderDetails.RemoveRange(orderDetails);
                _context.SaveChanges();
            }
            var orders = _context.Orders.Where(x => x.EmployeeId == EmployeeId).ToList();
            if(orders.Count > 0)
            {
                _context.Orders.RemoveRange(orders);
                _context.SaveChanges();

            }
            Model.Employee employee = _context.Employees.FirstOrDefault(x => x.EmployeeId == EmployeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return NoContent();
        }
    }
}
