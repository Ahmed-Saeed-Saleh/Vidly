using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VidlyApp.Models;
using VidlyApp.ViewModels;

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
        public ActionResult New()
        {
            var membershipTypes = _context.membershipTypes.ToList();
            var viewModel = new CustomerViewModel
            {
                MembershipTypes = membershipTypes,
            };
            return View(viewModel);
        }
        [HttpPost] // to be called using httppost not htttpget
                   // if the action modfieies a data base it should be accessible using
                   // http post not http get 
        public ActionResult Save(Customer customer)
        {
            if(customer.Id == 0)    
                _context.Customers.Add(customer);
            else
            {
                var cust = _context.Customers.Single(c => c.Id == customer.Id);
                cust.Name = customer.Name;
                cust.BirthDate = customer.BirthDate;
                cust.MembershipTypeId = customer.MembershipTypeId;
                cust.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.membershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);
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