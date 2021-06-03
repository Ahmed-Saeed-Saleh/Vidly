using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using VidlyApp.Dtos;
using VidlyApp.Models;

namespace VidlyApp.Controllers.api
{
    public class CustomersController : ApiController
    {
        
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            var custDto =  _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
            return Ok(custDto);
        }
        // GET /api/customers/1
        public IHttpActionResult GetCustomers(int custID)
        {
            var customer = _context.Customers.SingleOrDefault(s => s.Id == custID);
            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }
        //POST /api/customers/1
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cust = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(cust);
            _context.SaveChanges();

            customerDto.Id = cust.Id;

            return Created(new Uri(Request.RequestUri + "/"+ cust.Id),customerDto);
        }
        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cust = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (cust == null)
                return NotFound();
            Mapper.Map(customerDto, cust);
            _context.SaveChanges();
            return Ok();
        }
        //DELETE   
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cust = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (cust == null)
                return NotFound();

            _context.Customers.Remove(cust);
            _context.SaveChanges();
            return Ok();
        }
    }
}
