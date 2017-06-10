using Bussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using Data.Entity;

namespace TransmitterWEB.WebApi
{
    public class BaseGenerikApiController<T> : _baseApiController
    {
        public IBaseService<T> _service;
        
        public BaseGenerikApiController(IBaseService<T> service)
        {
            _service = service;
        }

        public T GetById(string Id)
        {
            return _service.GetById(Id);
        }

        public List<T> GetAllCustomer()
        {
            return _service.GetAll().ToList();
        }


        public T Insert(T entity)
        {
            return _service.Insert(entity);
        }

        public T Update(T entity)
        {
            return _service.Update(entity);
        }

        public void Delete(T entity)
        {
            _service.Delete(entity);
        }
    }
}
