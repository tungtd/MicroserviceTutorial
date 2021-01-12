using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Microservice.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Customer.Microservice.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private IApplicationDBContext _context;
        public CustomerController(IApplicationDBContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Entities.Customer product)
        {
            _context.Customers.Add(product);
            await _context.SaveChanges();
            return Ok(product.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _context.Customers.ToListAsync();
            if (products == null) return NotFound();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _context.Customers.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (customer == null) return NotFound();
            return Ok(customer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.Customers.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (customer == null) return NotFound();
            _context.Customers.Remove(customer);
            await _context.SaveChanges();
            return Ok(customer.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Entities.Customer customerUpdate)
        {
            var customer = _context.Customers.Where(a => a.Id == id).FirstOrDefault();
            if (customer == null) return NotFound();
            else
            {
                customer.Name = customerUpdate.Name;
                customer.City = customerUpdate.City;
                customer.Contact = customerUpdate.Contact;
                customer.Email = customerUpdate.Email;
                
                await _context.SaveChanges();
                return Ok(customer.Id);
            }
        }
    }
}
