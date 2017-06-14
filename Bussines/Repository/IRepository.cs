using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Bussines
{
    public interface IRepository<TEntity>
    {
        #region Public Methods

        DbContext Context { get; }

        IQueryable<TEntity> GetAll();

        TEntity GetById(string Id);

        TEntity GetById(Guid Id);


        TEntity Insert(TEntity entity);
        bool InsertAll(IList<TEntity> entities);

        TEntity Update(TEntity entity, bool modify = true);

        void Delete(TEntity entity);
        void DeleteFull(TEntity entity);
        
        void SaveChanges();

        void Dispose();
        #endregion Public Methods
    }
}