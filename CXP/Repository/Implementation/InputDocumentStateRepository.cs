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
    public class InputDocumentStateRepository : IRepository<InputDocumentState>
    {

        private readonly IDbConnection dbConnection = DbHelper.instance;
        public bool DeleteEntity(InputDocumentState entity)
        {
            return dbConnection.Delete(entity);
        }

        public InputDocumentState FindEntity(long? entityId)
        {
            return dbConnection.Get<InputDocumentState>(entityId);
        }

        public IEnumerable<InputDocumentState> GetAllEntity()
        {
            return dbConnection.GetAll<InputDocumentState>();
        }

        public long InsertEntity(InputDocumentState entity)
        {
            return dbConnection.Insert(entity);
        }

        public bool UpdateEntity(InputDocumentState entity)
        {
            return dbConnection.Update(entity);
        }
    }
}