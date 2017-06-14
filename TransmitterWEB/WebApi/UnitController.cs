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
    public class UnitController : BaseGenerikApiController<Unit>
    {
        IUnitService _srv;
        public UnitController(IUnitService service) : base(service)
        {
            _srv = service;
        }
        public void test()
        {
            var unit = _service.GetById("3b923e85-e767-480c-82b9-26833a6e178d");
            unit.Fields = new List<Field>();
            Field f = new Field();
            f.Name = "deneme";
            f.UnitId = Guid.Parse("3b923e85-e767-480c-82b9-26833a6e178d");
            f.FieldTypeId = Guid.Parse("8d3de3e7-93e6-4f16-b2f9-42b806de5daa");
            f.FieldValue = new List<FieldValue>() { new FieldValue() { Value = "55", CreateTime = DateTime.Now } };
            unit.Fields.Add(f);
            _service.Update(unit);
        }
        public HttpResponseMessage getUnitFieldforCharts(string Id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _srv.GetFieldForCharts(Id));
        }

    }
}
