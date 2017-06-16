using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bussines;
using Data.Extensions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace TransmitterWEB.WebApi
{
    public class DashBoardController : BaseGenerikApiController<DashBoard>
    {
        IDashBoardService _srv;
        public DashBoardController(IDashBoardService service) : base(service)
        {
            _srv = service;
        }
        public HttpResponseMessage getInfo()
        {
            var Id = User.Identity.GetCustomerId();
            return Request.CreateResponse(HttpStatusCode.OK, _srv.GetInfo(Id));
        }
        public HttpResponseMessage getCharts()
        {
            var Id = User.Identity.GetUserId();
            return Request.CreateResponse(HttpStatusCode.OK, _srv.GetChartsByUserId(Id));
        }

        public HttpResponseMessage addChart(DashBoard model)
        {
            DashBoard result = null;
            model.UserId = Guid.Parse(User.Identity.GetUserId());
            var check = _srv.GetAll().Where(x => x.UserId == model.UserId && model.FieldId == x.FieldId).Count();
            if (check == 0)
                result = base.Insert(model);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        [HttpPost]
        public HttpResponseMessage deleteChart(DashBoard model)
        {
            DashBoard result = _srv.GetById(model.Id.ToString());
            if (result != null)
                _srv.Delete(result);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
