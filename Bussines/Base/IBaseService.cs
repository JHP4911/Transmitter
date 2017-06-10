using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Bussines
{
    public interface IBaseService<T>
    {
        #region Public Methods

        void Delete(T entity);
        void DeleteFull(T entity);

        IQueryable<T> GetAll();

        T GetById(string id);

        T Insert(T entity);

        bool InsertAll(IList<T> entities);

        T Update(T entity);

        DbContext Context();

        #endregion Public Methods
    }
}