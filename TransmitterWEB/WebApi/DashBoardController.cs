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
        public HttpResponseMessage getUnitFieldforCharts(string Id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _srv.GetChartsByUserId(Id));
        }

    }
}
