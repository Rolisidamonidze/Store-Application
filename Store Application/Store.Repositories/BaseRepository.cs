using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using DatabaseHelper;
using Microsoft.Extensions.Configuration;

namespace Store.Repositories {
   public class BaseRepository<TModel> where TModel : new() {

      protected readonly Lazy<string> _insertOperation, _updateOperation, _deleteOperation;
      protected readonly Lazy<IEnumerable<string>> _insertParameters, _updateParameters, _deleteParameters;
      private string _connectionString;


      protected SqlDatabase _database;

      public BaseRepository() {
         _connectionString = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build().GetConnectionString("Market");

         _database = new SqlDatabase(_connectionString, true);

         _insertOperation = new Lazy<string>(() => $"Insert{typeof(TModel).Name}_SP");
         _updateOperation = new Lazy<string>(() => $"Update{typeof(TModel).Name}_SP");
         _deleteOperation = new Lazy<string>(() => $"Delete{typeof(TModel).Name}_SP");
         _insertParameters = new Lazy<IEnumerable<string>>(() => LoadProcedureParameterNames("Insert"));
         _updateParameters = new Lazy<IEnumerable<string>>(() => LoadProcedureParameterNames("Update"));
         _deleteParameters = new Lazy<IEnumerable<string>>(() => LoadProcedureParameterNames("Delete"));
      }

      #region CRUD

      public virtual int Insert(TModel model, int currentUserId) {
         return Convert.ToInt32(_database.ExecuteScalar(
            _insertOperation.Value,
            CommandType.StoredProcedure,
            GetSqlParameters(model, _insertParameters.Value, currentUserId)?.ToArray()));
      }

      public virtual int Update(TModel model, int currentUserId) {
         return Convert.ToInt32(_database.ExecuteScalar(
            _updateOperation.Value,
            CommandType.StoredProcedure,
            GetSqlParameters(model, _updateParameters.Value, currentUserId)?.ToArray()));
      }

      public virtual int Delete(TModel model, int currentUserId) {
         return Convert.ToInt32(_database.ExecuteScalar(
            _deleteOperation.Value,
            CommandType.StoredProcedure,
            GetSqlParameters(model, _deleteParameters.Value, currentUserId)?.ToArray()));
      }

      public virtual int Delete(int id, int currentUserId) {
         return _database.ExecuteNonQuery(
            _deleteOperation.Value,
            CommandType.StoredProcedure,
            new SqlParameter[] {
               new SqlParameter
               {
                  Value=id,
                  ParameterName = "@ID",
               },
               new SqlParameter
               {
                  Value = currentUserId,
                  ParameterName = "@CurrentUserID"
               }
            });
      }

      public virtual IEnumerable<TModel> Select() {
         var table = _database.GetDataTable($"select * from Get{typeof(TModel).Name}s");
         var properties = typeof(TModel).GetProperties();
         foreach (DataRow row in table.Rows) {
            var model = new TModel();
            foreach (var property in properties) {
               if (table.Columns.Contains(property.Name)) {
                  property.SetValue(model, row[property.Name] is DBNull ? null : row[property.Name]);
               }
            }
            yield return model;
         }
      }

      #endregion

      #region Helper Methods
      protected IEnumerable<SqlParameter> GetSqlParameters(TModel model, IEnumerable<string> parameters, int currentUserID) {
         if (!parameters.Any()) yield break;
         PropertyInfo[] properties = model.GetType().GetProperties();

         foreach (var property in properties) {
            if (parameters.Contains(property.Name.ToLower())) {
               yield return new SqlParameter()
               {
                  Value = property.GetValue(model) == null ? DBNull.Value : property.GetValue(model),
                  ParameterName = property.Name
               };
            }
         }

         yield return new SqlParameter()
         {
            Value = currentUserID,
            ParameterName = "@CurrentUserID"
         };
      }

      protected IEnumerable<string> LoadProcedureParameterNames(string operation) {
         if (ProcedureExists(operation)) {
            DataTable dataTable = GetProcedureParametersTable(operation);
            foreach (DataRow row in dataTable.Rows) {
               yield return row["Name"].ToString().Substring(1).ToLower();
            }
         } else {
            throw new NotSupportedException("Procedure doesn't exist");
         }
      }

      private DataTable GetProcedureParametersTable(string operation) {
         return _database.GetDataTable(
          "GetProcedureParameters_SP",
          CommandType.StoredProcedure,
          new SqlParameter()
          {
             Value = $"{operation}{typeof(TModel).Name}_SP",
             ParameterName = "@ProcedureName"
          });
      }

      private bool ProcedureExists(string operation) {
         return Convert.ToBoolean(_database.ExecuteScalar(
             "ProcedureExists_SP",
             CommandType.StoredProcedure,
             new SqlParameter()
             {
                Value = $"{operation}{typeof(TModel).Name}_SP",
                ParameterName = "@ProcedureName"
             }));
      }

      protected SqlParameter GetIdParameter(int id) {
         return new SqlParameter
         {
            Value = id,
            ParameterName = "@ID"
         };
      }

      #endregion

      #region Transactions

      public SqlTransaction BeginTransaction() {
         return _database.BeginTransaction();
      }

      public void RollbackTransaction() {
         _database.RollbackTransaction();
      }

      public void CommitTransaction() {
         _database.CommitTransaction();
      }

      public void ShareTransaction(SqlTransaction transaction) {
         _database.ShareTransaction(transaction);
      }

      #endregion
   }
}