using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RocketApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketApi.Models;

namespace RocketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CustomersController(ApplicationContext context)
        {
            _context = context;
        }

        //-------------------------------------------------- Get all Customers ----------------------------------------------------\\

        //Get: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.customers.ToListAsync();
        }

        [HttpGet("{customer_email}")]
        // Email of the customer that we want to verify existence of
        public bool GetIfExist(string customer_email)
        {
            // Verify if a customer with that email exists
            return _context.customers.Any(e => e.email_of_the_company_contact == customer_email);
        }

        [HttpGet("getId/{customer_email}")]
        // Return the id of a customer that we want to find with the email
        public async Task<long> GetCustomerId(string customer_email)
        {
            var customer =  await _context.customers.Where(c => c.email_of_the_company_contact == customer_email).FirstAsync();
            return customer.id;
        }


    }
}