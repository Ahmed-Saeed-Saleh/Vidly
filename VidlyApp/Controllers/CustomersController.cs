using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VidlyApp.Models;

namespace VidlyApp.Controllers
{

    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=> c.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var cust = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (cust == null)
                return HttpNotFound();
            return View(cust);
        }
    }
}