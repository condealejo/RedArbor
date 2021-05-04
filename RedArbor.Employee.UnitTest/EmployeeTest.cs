using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using RedArbor.Employee.API.Controllers;
using RedArbor.Employee.API.Services.Concrete;
using RedArbor.Employee.API.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace RedArbor.Employee.UnitTest
{
    /// <summary>
    /// Aqui se prueba unitariamente cada uno de los metodos expuestos en el API RedArbor.Employee.API.
    /// </summary>
    public class EmployeeTest
    {
        EmployeeController _controller;
        IEmployeeService _service;

        public EmployeeTest() 
        {
            _service = new EmployeeService();
            _controller = new EmployeeController(_service);
        }

        [Test]
        public async Task GetEmployees_ReturnOK()
        {
            var result = await _controller.GetAllEmployees();
            var status = result as ObjectResult;
            Assert.AreEqual(200, status.StatusCode);
        }

        [Test]
        public async Task InsertEmployee_ReturnOK()
        {
            var result = await _controller.InsertEmployee(new Entities.Concrete.Employee.Employee()
            {
                CompanyID = 100,
                Name = "Pruebas Unitarias NUnit",
                UserName = "TestUnit1",
                Email = "alejandro.alarcon@TestUnit.com",
                Password = "HolaMundo2021",
                Telephone = "+573124959932",
                Fax = "None",
                PortalID = 1,
                RoleID = 1,
                StatusID = 1, 
                LastLogin = DateTime.Now,
                CreatedOn = DateTime.Now
            });

            var status = result as ObjectResult;
            Assert.AreEqual(200, status.StatusCode);
        }

        [Test]
        public async Task UpdateEmployee_ReturnOK()
        {
            var result = await _controller.UpdateEmployee(100, new Entities.Concrete.Employee.Employee()
            {
                CompanyID = 100,
                Name = "Update Unitarias NUnit",
                UserName = "TestUnit2",
                Email = "alejandro.alarcon@TestUnit.com",
                Password = "2021HolaMundo",
                Telephone = "+573124959932",
                Fax = "Nuevo Fax 12345",
                PortalID = 2,
                RoleID = 2,
                StatusID = 1,
                LastLogin = DateTime.Now,
                UpdatedOn = DateTime.Now
            });

            var status = result as ObjectResult;
            Assert.AreEqual(200, status.StatusCode);
        }

        [Test]
        public async Task GetEmployeeByCompanyID_ReturnOK()
        {
            var result = await _controller.GetEmployeeByCompanyID(100);
            var status = result as ObjectResult;
            Assert.AreEqual(200, status.StatusCode);
        }

        [Test]
        public async Task DeleteEmployee_ReturnOK()
        {
            var result = await _controller.DeleteEmployee(100);
            var status = result as ObjectResult;
            Assert.AreEqual(200, status.StatusCode);
        }
    }
}
