using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransmitterWEB.WebApi;
using Data.Entity;
using Bussines;
using Moq;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace TransmitterWEB.Tests.Api
{
    [TestClass]
    public class BaseApiControllerTest
    {
        Mock<IBaseService<Customer>> _service = new Mock<IBaseService<Customer>>();

        Customer d;

        [TestInitialize]
        public void TestInitialize()
        {
            d = new Customer();
            d.Id = new Guid();
            d.Name = "firma Adı";
            d.Email = "sdea";
        }
        [TestMethod]
        public void GetById()
        {
            TestInitialize();
            // Arrange
            _service.Setup(x => x.GetById(d.Id.ToString())).Returns(d);
            BaseGenerikApiController<Customer> controller = new BaseGenerikApiController<Customer>(_service.Object);

            // Act
            var result = controller.GetById(d.Id.ToString());
            // Assert
            Assert.AreEqual(d, result);
        }

        [TestMethod]
        public void GetByIdWithNullData()
        {
            TestInitialize();

            // Arrange
            _service.Setup(x => x.GetById(d.Id.ToString())).Returns(d);
            BaseGenerikApiController<Customer> controller = new BaseGenerikApiController<Customer>(_service.Object);
            // Act
            var result = controller.GetById(null);
            // Assert
            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void GetAllData()
        {
            TestInitialize();
            List<Customer> dd = new List<Customer>();
            dd.Add(d);
            // Arrange
            _service.Setup(x => x.GetAll()).Returns(dd.AsQueryable());
            BaseGenerikApiController<Customer> controller = new BaseGenerikApiController<Customer>(_service.Object);

            // Act
            var result = controller.GetAllCustomer();
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void InsertBaseData()
        {
            TestInitialize();
            // Arrange
            _service.Setup(x => x.Insert(d)).Returns(d);
            BaseGenerikApiController<Customer> controller = new BaseGenerikApiController<Customer>(_service.Object);
            // Act
            var result = controller.Insert(d);
            // Assert
            Assert.AreEqual(d, result);
        }

        [TestMethod]
        public void UpdateBaseData()
        {
            TestInitialize();
            // Arrange
            _service.Setup(x => x.Update(d)).Returns(d);
            BaseGenerikApiController<Customer> controller = new BaseGenerikApiController<Customer>(_service.Object);
            // Act
            var result = controller.Update(d);
            // Assert
            Assert.AreEqual(d, result);
        }

        [TestMethod]
        public void DeleteBaseApi()
        {
            TestInitialize();
            // Arrange
            _service.Setup(x => x.Delete(d));
            BaseGenerikApiController<Customer> controller = new BaseGenerikApiController<Customer>(_service.Object);
            // Act
            controller.Delete(d);
            // Assert
        
        }
    }
}
