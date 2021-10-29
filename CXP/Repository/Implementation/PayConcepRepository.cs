
using CXP.App.Repository.Interface;
using CXP.Models;
using CXP.Utilities;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CXP.App.DAL.Repository.Implementation
{
    public class PayConcepRepository : IRepository<PayConcept>
    {

        private readonly IDbConnection DbConnection = DbHelper.instance;

      
        public bool DeleteEntity(PayConcept entity)
        {
            return DbConnection.Delete(entity);
        }

        public PayConcept FindEntity(long? entityId)
        {
            return DbConnection.Get<PayConcept>(entityId);
        }

        public IEnumerable<PayConcept> GetAllEntity()
        {
            return DbConnection.GetAll<PayConcept>();
        }

        public long InsertEntity(PayConcept entity)
        {
            return DbConnection.Insert(entity);
        }

        public bool UpdateEntity(PayConcept entity)
        {
            return DbConnection.Update(entity);
        }
    }
}