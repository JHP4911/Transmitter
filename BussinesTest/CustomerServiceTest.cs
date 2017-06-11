using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Entity;
using Bussines;
using Moq;
using System.Collections.Generic;
using System.Linq;
namespace BussinesTest
{
    [TestClass]
    public class CustomerServiceTest
    {
        Mock<IRepository<Customer>> _repos = new Mock<IRepository<Customer>>();
        Mock<IRepository<Unit>> _UnitRepo = new Mock<IRepository<Unit>>();


        [TestMethod]
        public void CreateCustomer()
        {
            //Arrange
            Customer d = new Customer();
            _repos.Setup(x => x.Insert(d)).Returns(d);
            var _customerSrv = new CustomerService(_repos.Object, _UnitRepo.Object);
            //Act
            var result = _customerSrv.Insert(d);
            //Assert
            Assert.AreEqual(result, d);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateCustomerWithNull()
        {
            //Arrange
            Customer d = new Customer();            
            _repos.Setup(x => x.Insert(d)).Returns(d);
            var _customerSrv = new CustomerService(_repos.Object, _UnitRepo.Object);
            //Act
            var result = _customerSrv.Insert(null);
            //Assert
            
        }

        [TestMethod]
        public void getCustomerById()
        {
            //Arrange
            Customer d = new Customer();
            d.Id = Guid.NewGuid();
            _repos.Setup(x => x.GetById(d.Id.ToString())).Returns(d);
            var _customerSrv = new CustomerService(_repos.Object, _UnitRepo.Object);
            //Act
            var result = _customerSrv.GetById(d.Id.ToString());
            //Assert
            Assert.AreEqual(result, d);

        }
        [TestMethod]
        public void getCustomerUnits()
        {
            //Arrange
            IList<Unit> dd = new List<Unit>();
            Unit d = new Unit();
            d.CustomerId =Guid.Parse("3b923e85-e767-480c-82b9-26833a6e178d");
            d.Name = "name";
            d.Fields = new List<Field>();
            d.Fields.Add(new Field());
            dd.Add(d);
            _UnitRepo.Setup(x => x.GetAll()).Returns(dd.AsQueryable());
            var _customerSrv = new CustomerService(_repos.Object, _UnitRepo.Object);
            //Act
            var result = _customerSrv.getCustomerForNavigation("3b923e85-e767-480c-82b9-26833a6e178d");
            //Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]        
        public void getCustomerWithNull()
        {
            //Arrange
            var _customerSrv = new CustomerService(_repos.Object, _UnitRepo.Object);
            //Act
            var result = _customerSrv.GetById(null);
            //Assert
            Assert.AreEqual(result, null);

        }
    }
}
