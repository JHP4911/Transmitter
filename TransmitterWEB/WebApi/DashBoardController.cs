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
    public class DashBoardController : BaseGenerikApiController<DashBoard>
    {
        IDashBoardService _srv;
        public DashBoardController(IDashBoardService service) : base(service)
        {
            _srv = service;
        }
        public HttpResponseMessage getCharts()
        {
            //TODO userıd yi al
            var Id = "fafb7552-3161-493e-ae77-ffe6b7080344";
            return Request.CreateResponse(HttpStatusCode.OK, _srv.GetChartsByUserId(Id));
        }

        public HttpResponseMessage addChart(DashBoard model)
        {
            //TODO userıd yi al
            DashBoard result = null;
            var uId = Guid.Parse("fafb7552-3161-493e-ae77-ffe6b7080344");
            model.UserId = uId;
            var check = _srv.GetAll().Where(x => x.UserId == uId && model.FieldId == x.FieldId).Count();
            if (check == 0)
                result = base.Insert(model);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        [HttpPost]
        public HttpResponseMessage deleteChart(DashBoard model)
        {
            //TODO userıd yi al
            DashBoard result = _srv.GetById(model.Id.ToString());
            if (result != null)
                _srv.Delete(result);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
