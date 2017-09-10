using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bussines;
using Data.Extensions;

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
            //TODO silinecek
            var unit = _service.GetById("e4039f01-bc8e-45b5-b95b-19fc6f4b53f8");
            unit.Fields = new List<Field>();
            Field f = new Field();
            f.Name = "deneme";
            f.UnitId = Guid.Parse("e4039f01-bc8e-45b5-b95b-19fc6f4b53f8");
            f.FieldTypeId = Guid.Parse("0a694846-6d5e-413e-8574-2616d2bedc80");
            f.FieldValue = new List<FieldValue>() { new FieldValue() { Value = "55", CreateTime = DateTime.Now } };
            unit.Fields.Add(f);
            _service.Update(unit);
        }
        public HttpResponseMessage getUnitFieldforCharts(string Id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _srv.GetFieldForCharts(Id));
        }

        public override Unit Insert(Unit model)
        {
            model.CustomerId =Guid.Parse(User.Identity.GetCustomerId());
            return base.Insert(model);
        }
        [HttpGet]
        public void DeleteUnit(string Id)
        {
            var entity = _service.GetById(Id);
            base.Delete(entity);
        }
        
    }
}
