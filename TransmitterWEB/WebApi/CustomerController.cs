using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Bussines;
using Newtonsoft.Json;
using Data;
using System.Net.Http;
using System.Net;

namespace TransmitterWEB.WebApi
{
    public class CustomerController : BaseGenerikApiController<Customer>
    {
        ICustomerService _srv;

        public CustomerController(ICustomerService service
            ) : base(service)
        {
            _srv = service;

        }
        public HttpResponseMessage GetCustomerForNavigation()
        {

            var custId = "3b923e85-e767-480c-82b9-26833a6e178d";// User.Identity.GetCustomerId();
            if (!string.IsNullOrEmpty(custId))
                return Request.CreateResponse(HttpStatusCode.OK, _srv.getCustomerForNavigation(custId));
            return null;
        }
    }
}
