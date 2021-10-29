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
    public class InputDocumentRepository : IRepository<InputDocument>
    {
        private readonly IDbConnection dbConnection = DbHelper.instance;

        public bool DeleteEntity(InputDocument entity)
        {
           return dbConnection.Delete(entity);
        }

        public InputDocument FindEntity(long? entityId)
        {
            return dbConnection.Get<InputDocument>(entityId);
        }

        public IEnumerable<InputDocument> GetAllEntity()
        {
            return dbConnection.GetAll<InputDocument>();
        }

        public long InsertEntity(InputDocument entity)
        {
            return dbConnection.Insert(entity);
        }

        public bool UpdateEntity(InputDocument entity)
        {
            return dbConnection.Update(entity);
        }
    }
}