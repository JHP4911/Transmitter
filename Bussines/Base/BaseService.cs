using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Bussines
{
    public class BaseService<T> where T : class
    {
        #region Private Fields

        public IRepository<T> _repo;

        #endregion Private Fields

        #region Public Constructors
        public DbContext Context()
        {
            return _repo.Context;
        }
        public BaseService(IRepository<T> repo)
        {
            _repo = repo;
        }

        #endregion Public Constructors

        #region Public Methods

        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity is null");
            _repo.Delete((T)entity);
            _repo.SaveChanges();
        }

        public virtual void DeleteFull(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity is null");
            _repo.DeleteFull((T)entity);
            _repo.SaveChanges();
        }

        public virtual IQueryable<T> GetAll()
         {
            return _repo.GetAll();
        }

        public virtual T GetById(string id)
        {
            return _repo.GetById(id);
        }

        public virtual T Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity is null");
            _repo.Insert((T)entity);
            return entity;
        }

        public virtual bool InsertAll(IList<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities are null");            
            return _repo.InsertAll(entities); 
        }
        public virtual T Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity is null");
            _repo.Update((T)entity);
            return entity;
        }

        #endregion Public Methods
    }
}