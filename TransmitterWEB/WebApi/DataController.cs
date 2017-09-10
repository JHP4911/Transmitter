using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bussines;
using Data;
using System.Web;

namespace TransmitterWEB.WebApi
{
    [AllowAnonymous]
    public class DataController : _baseApiController
    {
        
        IFieldValueService _service;
        IFieldService _fieldservice;
        public DataController(IFieldValueService service, IFieldService fieldservice)
        {
            _service = service;
            _fieldservice = fieldservice;
        }
        [HttpGet]
        public void Set()
        {
            var appKey = HttpContext.Current.Request.QueryString.GetValues("appKey").FirstOrDefault();
            string value;
            List<FieldValue> values = new List<FieldValue>();
            FieldValue item;
            DateTime dt = DateTime.Now;
            foreach (var key in HttpContext.Current.Request.QueryString.AllKeys.Where(x => !x.Contains("appKey")))
            {
                value = HttpContext.Current.Request.QueryString.GetValues(key).FirstOrDefault();
                if (string.IsNullOrEmpty(value))
                    continue;
                item = new FieldValue()
                {
                    FieldId = Guid.Parse(key),
                    Value = value,
                    CreateTime = dt
                };
                values.Add(item);
            }
            _service.InsertValue(appKey, values);
        }
        [HttpPost]
        public void SetPost([FromBody]FieldValueMainModel data)
        {

        }
        [HttpGet]
        public object Read()
        {
            var appKey = Guid.Parse(HttpContext.Current.Request.QueryString.GetValues("appKey").FirstOrDefault());
            var fieldKey = Guid.Parse(HttpContext.Current.Request.QueryString.GetValues("fieldKey").FirstOrDefault());
            var a= _fieldservice.GetAll().Where(x => x.Id == fieldKey && x.UnitId == appKey).FirstOrDefault().CheckValue;
            return a;
        }
    }
}
