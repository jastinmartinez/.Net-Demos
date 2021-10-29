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
    public class AccountingSeatRepository : IRepository<AccountingSeat>
    {

        private readonly IDbConnection dbConnection = DbHelper.instance;

        public bool DeleteEntity(AccountingSeat entity)
        {
            return dbConnection.Delete(entity);
        }

        public AccountingSeat FindEntity(long? entityId)
        {
            return dbConnection.Get<AccountingSeat>(entityId);
        }

        public IEnumerable<AccountingSeat> GetAllEntity()
        {
            return dbConnection.GetAll<AccountingSeat>();
        }

        public long InsertEntity(AccountingSeat entity)
        {
            return dbConnection.Insert(entity);
        }

        public bool UpdateEntity(AccountingSeat entity)
        {
            return dbConnection.Update(entity);
        }
    }
}