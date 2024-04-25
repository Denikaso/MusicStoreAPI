﻿using Microsoft.AspNetCore.Http;
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
        public void Post(string name, string email, string phoneNumber)
        {
            new CustomerBD().Create(name, email, phoneNumber);
        }

        [HttpPut("UpdateCustomer/{id}")]
        public void Put(int id, string name, string email, string phoneNumber)
        {
            new CustomerBD().UpdateCustomer(id, name, email, phoneNumber);
        }

        [HttpDelete("Customer/{id}/Delete")]
        public void Delete(int id)
        {
            new CustomerBD().Delete(id);
        }
    }
}