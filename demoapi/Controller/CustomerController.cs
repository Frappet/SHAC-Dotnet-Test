using Microsoft.AspNetCore.Mvc;
using customerTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace customerTest.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CustomerController : ControllerBase
  {
    private static List<Customer> customers = new();

    public CustomerController()
    {
      //add data to customer
      var cust1 = new Customer
      {
        Id = "71f48680-e45e-43f1-bf3a-966226cb2b22",
        Name = "สมหมาย"
      };

      // เพิ่มเฉพาะ ที่ไม่มีไอดีอยู่ใน list
      if (!customers.Any(c => c.Id == cust1.Id))
      {
        customers.Add(cust1);
      }
      var cust2 = new Customer
      {
        Id = "71f48680-e45e-43f1-bf3a-966226cb2b21",
        Name = "สมปอง"
      };

      // เพิ่มเฉพาะ ที่ไม่มีไอดีอยู่ใน list
      if (!customers.Any(c => c.Id == cust2.Id))
      {
        customers.Add(cust2);
      }
    }

    // GET: api/customer
    [HttpGet]
    public ActionResult<List<Customer>> GetCustomers()
    {
      return Ok(customers);
    }

    // POST: api/customer
    [HttpPost]
    public ActionResult<Customer> AddCustomer([FromBody] Customer newCustomer)
    {
      newCustomer.Id = Guid.NewGuid().ToString(); // Gen id ใหม่
      customers.Add(newCustomer);
      return Ok(newCustomer);
    }

    // PUT: api/customer/{id}
    [HttpPut("{id}")]
    public ActionResult<Customer> EditCustomer(string id, [FromBody] Customer updatedCustomer)
    {
      var customer = customers.FirstOrDefault(c => c.Id == id);
      if (customer == null)
      {
        return NotFound("Customer not found.");
      }

      customer.Name = updatedCustomer.Name;
      return Ok(customer);
    }

    // DELETE: api/customer/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteCustomer(string id)
    {
      var customer = customers.FirstOrDefault(c => c.Id == id);
      if (customer == null)
      {
        return NotFound("Customer not found.");
      }

      customers.Remove(customer);
      return Ok("Customer deleted successfully.");
    }
  }
}
