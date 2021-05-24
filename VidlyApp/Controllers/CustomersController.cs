using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VidlyApp.Models;

namespace VidlyApp.Controllers
{

    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var cust = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (cust == null)
                return HttpNotFound();
            return View(cust);
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer    {   Id = 1 , Name ="Ahmed"  },
                new Customer    {  Id = 2 , Name = "Salma"  }

            };
        }
    }
}