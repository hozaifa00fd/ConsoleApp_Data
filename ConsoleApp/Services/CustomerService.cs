﻿using ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly AddressService _addressService;
        private readonly RoleService _roleService;

        public CustomerService(CustomerRepository customerRepository, AddressService addressService, RoleService roleService)
        {
            _customerRepository = customerRepository;
            _addressService = addressService;
            _roleService = roleService;
        }



        public CustomerEntity CreateCustomer(string firstName, string lastName, string email, string roleName, string stretName, string postalCode, string city)
        {
            var roleEntity = _roleService.CreateRole(roleName);
            var addressEntity = _addressService.CreateAddress(stretName, postalCode, city);

            var customerEntity = new CustomerEntity
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                RoleId = roleEntity.Id,
                AddressId = addressEntity.Id,
            };

            customerEntity = _customerRepository.Create(customerEntity);
            return customerEntity;
        }





        public CustomerEntity GetCustomerById(string email)
        {
            var customerEntity = _customerRepository.Get(x => x.Email == email);
            return customerEntity;
        }

        public IEnumerable<CustomerEntity> GetCustomers()
        {
            var customers = _customerRepository.GetAll();
            return customers;
        }

        public CustomerEntity UpdateCustomer(CustomerEntity customerEntity)
        {
            var UpdatedCustomerEntity = _customerRepository.Update(x => x.Id == customerEntity.Id, customerEntity);
            return UpdatedCustomerEntity;
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.Delete(x => x.Id == id);
        }
    }
}
