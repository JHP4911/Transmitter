using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Bussines;
using Newtonsoft.Json;
using Data;
using System.Net.Http;
using System.Net;
using Data.Extensions;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace TransmitterWEB.WebApi
{
    public class CustomerController : BaseGenerikApiController<Customer>
    {
        ICustomerService _srv;

        public CustomerController(ICustomerService service) : base(service)
        {
            _srv = service;

        }
        public HttpResponseMessage GetCustomerForNavigation()
        {


            var custId = User.Identity.GetCustomerId();
            if (!string.IsNullOrEmpty(custId))
                return Request.CreateResponse(HttpStatusCode.OK, _srv.getCustomerForNavigation(custId));
            return null;
        }
        public HttpResponseMessage GetCustemer()
        {

            var custId = User.Identity.GetCustomerId();
            var d = _srv.GetById(custId);
            return Request.CreateResponse(HttpStatusCode.OK, new { d.Id, d.Name, d.Phone, d.Email });
        }
    }
}
