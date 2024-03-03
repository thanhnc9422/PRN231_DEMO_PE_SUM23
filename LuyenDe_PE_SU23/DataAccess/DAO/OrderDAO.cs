using LuyenDe_PE_SU23.Model;

namespace LuyenDe_PE_SU23.DataAccess.DAO
{
    public class OrderDAO
    {
        readonly PE_PRN231_Sum23B5Context _context = new PE_PRN231_Sum23B5Context();
        public OrderDAO() { }
        public OrderDAO(PE_PRN231_Sum23B5Context context)
        {
            _context = context;
        }
        public List<Order> GetAllOrder()
        {
            return _context.Orders.ToList();
        }
    }
}
