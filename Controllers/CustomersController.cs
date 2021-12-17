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
using System.Text.Json;

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

        //-------------------------------------------------- Verify Customer Existance ----------------------------------------------------\\
        [HttpGet("{customer_email}")]
        // Email of the customer that we want to verify existence of
        public bool GetIfExist(string customer_email)
        {
            // Verify if a customer with that email exists
            return _context.customers.Any(e => e.email_of_the_company_contact == customer_email);
        }

        //-------------------------------------------------- Get customer Id  ----------------------------------------------------\\
        [HttpGet("getId/{customer_email}")]
        // Return the id of a customer that we want to find with the email
        public async Task<long> GetCustomerId(string customer_email)
        {
            var customer =  await _context.customers.Where(c => c.email_of_the_company_contact == customer_email).FirstAsync();
            return customer.id;
        }

        //-------------------------------------------------- Get customer information by email ----------------------------------------------------\\

        [HttpGet("information/{email}")]
        public async Task<string> GetCustomerInformation(string email)
        {
            //Return all the information of a customer that we want to find with the email
            var customer = await _context.customers.Where(c => c.email_of_the_company_contact == email).FirstAsync();
            // We return it in Json format
            var customerJson = JsonSerializer.Serialize(customer);
            return customerJson;
        }

        //-------------------------------------------------- Change Customer information ----------------------------------------------------\\\
        [HttpPut("updateProfile")]
        public async Task<IActionResult> updateProfile(Customer customer)
        {
            // Update the information of a customer.
            // Use the id that come in the content of the request to determine where to do the change

            // _context.Entry(inter).State = EntityState.Detached;
            _context.Entry(customer).State = EntityState.Modified;


            try
            
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!customersExists(customer.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool customersExists(long id)
        {
            return _context.interventions.Any(e => e.id == id);
        }

        private async Task<Customer> Customer(long id)
        {
            return await _context.customers.FindAsync(id);
        }
    }
}