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
using System.Web;
using Microsoft.AspNet.Identity.Owin;

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

        public List<T> GetAll()
        {
            return _service.GetAll().ToList();
        }


        public virtual T Insert(T entity)
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

        #region User
        //private ApplicationUserManager UserManager
        //{
        //    get { return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        //}
       
        #endregion
    }
}
