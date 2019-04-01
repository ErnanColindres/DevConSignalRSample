using System;
using System.Collections.Generic;
using System.Text;

namespace DevConSignalRSampleDataAccessLayer.Repositories.Base.Interfaces
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Find(Guid id);
        int Complete();
        void Create(TEntity entity);
    }
}
