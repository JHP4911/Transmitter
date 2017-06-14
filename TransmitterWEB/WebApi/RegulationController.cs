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
    public class RegulationController : BaseGenerikApiController<Regulation>
    {
        IRegulationService _Srv;
        public RegulationController(IRegulationService service) : base(service)
        {
            _Srv = service;
        }

    }
}
