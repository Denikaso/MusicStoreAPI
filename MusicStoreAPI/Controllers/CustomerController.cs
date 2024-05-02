using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreLibrary;
using TestStore;

namespace MusicStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        [HttpGet("GetCustomers")]
        public IEnumerable<Customer> Get()
        {
            var customers = new CustomerBD().Read();
            return customers;
        }

        [HttpPost("NewCustomer")]
        public void Post(string name, string email, string phoneNumber, string address, string password, string role)
        {
            new CustomerBD().Create(name, email, phoneNumber, address, password, role);
        }

        [HttpPut("UpdateCustomer/{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            new CustomerBD().UpdateCustomer(id, customer.Name, customer.Email, customer.PhoneNumber, customer.Address, customer.Password, customer.Role);
        }

        [HttpDelete("Customer/{id}/Delete")]
        public void Delete(int id)
        {
            new CustomerBD().Delete(id);
        }

        [HttpGet("GetCustomerById/{Id}")]
        public Customer? GetCustomerById(int Id)
        {
            var customer = new CustomerBD().SearchById(Id);
            return customer;
        }
    }
}
