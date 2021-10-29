using CXP.App.Repository.Interface;
using CXP.Models;
using CXP.Utilities;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CXP.Repository.Implementation
{
    public class ProviderRepository : IRepository<Provider>
    {
        private readonly IDbConnection dbConnection = DbHelper.instance;

        public bool DeleteEntity(Provider entity)
        {
            return dbConnection.Delete(entity);
        }

        public Provider FindEntity(long? entityId)
        {
            return dbConnection.Get<Provider>(entityId);
        }

        public IEnumerable<Provider> GetAllEntity()
        {
            return dbConnection.GetAll<Provider>();
        }

        public long InsertEntity(Provider entity)
        {
            return dbConnection.Insert(entity);
        }

        public bool UpdateEntity(Provider entity)
        {
            return dbConnection.Update(entity);
        }
    }
}