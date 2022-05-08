using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyLJ.Models;
using System.Data.Entity;
using StudyLJ.ViewModel;

namespace StudyLJ.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = this._context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
        

        //GET: Customers/Details/{id}
        public ActionResult Details(int id)
        {
            var customer = this._context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
            
        }

        public ActionResult New()
        {
            var membershipTypes = this._context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };

            return View( "CustomerForm",viewModel );
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                this._context.Customers.Add(customer);
            }
            else
            {
                var customerInDB = this._context.Customers.Single(c => c.Id == customer.Id);

                customerInDB.Name = customer.Name;
                customerInDB.Birthdate = customer.Birthdate;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            this._context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = this._context.Customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = this._context.MembershipTypes.ToList()
            };

            return View("CustomerForm",viewModel);
        }
    }
}