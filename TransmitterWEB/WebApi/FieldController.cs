﻿using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bussines;

namespace TransmitterWEB.WebApi
{
    public class FieldController : BaseGenerikApiController<Field>
    {
        IFieldService _Srv;
        public FieldController(IFieldService service) : base(service)
        {
            _Srv = service;
        }

        public IList<FieldType> getFieldType()
        {
            return _Srv.getFeildTypes();
        }
    }
}
