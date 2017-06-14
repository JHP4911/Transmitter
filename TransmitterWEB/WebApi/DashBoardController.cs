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

    }
}
