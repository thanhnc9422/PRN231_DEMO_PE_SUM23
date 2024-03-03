using LuyenDe_PE_SU23.DataAccess.DAO;
using LuyenDe_PE_SU23.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LuyenDe_PE_SU23.Controllers
{
    [Route("api/Order")]
    [ApiController]
    public class Order : ControllerBase
    {
        readonly PE_PRN231_Sum23B5Context _context;
        public Order(PE_PRN231_Sum23B5Context context) { 
            _context = context;
        }
        [HttpGet("GetAllOrder")]
        public ActionResult GetAllOrder()
        {
           return Ok(_context.Orders.Include(x => x.Employee).Include(x => x.Customer).Select(x => new { x.OrderId, x.CustomerId, x.Customer.ContactName, x.EmployeeId, x.Employee.FirstName, x.Employee.LastName, x.Employee.Department.DepartmentName, x.OrderDate, x.ShipName}));
        }
        [HttpGet("GetOrderByDate/{From}/{To}")]
        public ActionResult<IEnumerable<Model.Order>> GetOrderByDate(DateTime From, DateTime To)
        {
            return _context.Orders.Where(x => x.OrderDate >= From && x.OrderDate <= To).ToList();
        }
    }
}
