﻿using WebApplication1.Models;

namespace AdventureWorks_WebAPI_refactor.Data
{
    public interface ICustomerRepo
    {
        public ICollection<Customer> GetCustomers();

        public Customer GetCustomer(int id);
        public void CreateCustomer(Customer customer);

        public void DeleteCustomer(int id);
    }
}
