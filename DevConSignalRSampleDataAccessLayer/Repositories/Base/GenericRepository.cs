using DevConSignalRSampleDataAccessLayer.Repositories.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevConSignalRSampleDataAccessLayer.Repositories.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        bool disposed = false;
        protected DbContext _dbContext;

        public GenericRepository(DbContext context)
        {
            _dbContext = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);            
        }

        protected virtual void Dispose(bool isdispose)
        {
            if (disposed)
                return;

            if (isdispose)
            {
                _dbContext.Dispose();
            }

            disposed = true;
        }

        public TEntity Find(Guid id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }
    }
}
