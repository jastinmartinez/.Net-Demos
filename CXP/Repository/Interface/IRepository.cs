using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CXP.App.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAllEntity();

        T FindEntity(long? entityId);

        long InsertEntity(T entity);

        bool UpdateEntity(T entity);

        bool DeleteEntity(T entity);
    }
}