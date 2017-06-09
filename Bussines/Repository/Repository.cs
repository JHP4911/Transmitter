using Data;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Bussines
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {

        protected readonly ApplicationDbContext _context;


        protected DbSet<TEntity> _dbSet;

        public DbContext Context
        {
            get
            {
                return this._context;
            }
        }

        public Repository(ApplicationDbContext context)
        {

            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual TEntity GetById(string id)
        {
            return _dbSet.Find(id);
        }


        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity, bool modify = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            _dbSet.Remove(entity);
        }


        public virtual void DeleteFull(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            _dbSet.Remove(entity);

        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();

            }
            catch (DbEntityValidationException dbEx)
            {
                string errorMessage = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(errorMessage, dbEx);
            }

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_context == null) return;
            _context.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private int GetIso8601WeekOfYear(DateTime time)
        {

            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

    }
}