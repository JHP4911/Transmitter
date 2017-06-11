using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bussines;

namespace TransmitterWEB.WebApi
{
    public class CustomerController : BaseGenerikApiController<Customer>
    {
        public CustomerController(ICustomerService service) : base(service)
        {
            _service = service;
        }
    }
}
