using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Entity;
using Bussines;
using Moq;

namespace BussinesTest
{
    [TestClass]
    public class CustomerServiceTest
    {
        Mock<IRepository<Customer>> _repos = new Mock<IRepository<Customer>>();


        [TestMethod]
        public void CreateCustomer()
        {
            //Arrange
            Customer d = new Customer();
            _repos.Setup(x => x.Insert(d)).Returns(d);
            var _customerSrv = new CustomerService(_repos.Object);
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
            var _customerSrv = new CustomerService(_repos.Object);
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
            var _customerSrv = new CustomerService(_repos.Object);
            //Act
            var result = _customerSrv.GetById(d.Id.ToString());
            //Assert
            Assert.AreEqual(result, d);

        }

        [TestMethod]        
        public void getCustomerWithNull()
        {
            //Arrange
            var _customerSrv = new CustomerService(_repos.Object);
            //Act
            var result = _customerSrv.GetById(null);
            //Assert
            Assert.AreEqual(result, null);

        }
    }
}
