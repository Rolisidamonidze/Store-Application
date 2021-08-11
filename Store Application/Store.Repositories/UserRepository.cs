using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Store.Models;
using System.Reflection;
using System.Linq;

namespace Store.Repositories {

   public class UserRepository : BaseRepository<User> {

      public UserRepository() : base() {
      }

      public object Authenticate(string username, string password) {
         return _database.ExecuteScalar(
            "Authenticate_SP",
            CommandType.StoredProcedure,
            new SqlParameter() { SqlDbType = SqlDbType.NVarChar, ParameterName = "Username", Value = username },
            new SqlParameter() { SqlDbType = SqlDbType.Char, ParameterName = "Password", Value = password });
      }

      public DataTable GetUserPermissions(int id) {
         return _database.GetDataTable(
            "GetUserPermissions_SP",
            CommandType.StoredProcedure,
            GetIdParameter(id));
      }

      public int InsertUserGroup(int targetUserId, int groupId, int currentUserId) {
         return _database.ExecuteNonQuery(
            "InsertUserGroup_SP",
            CommandType.StoredProcedure,
            new SqlParameter[]
            {
               new SqlParameter
               {
                  Value = targetUserId,
                  ParameterName = "@UserID"
               },
                new SqlParameter
               {
                  Value = currentUserId,
                  ParameterName = "@CurrentUserID"
               },
               new SqlParameter
               {
                  Value = groupId,
                  ParameterName = "@GroupID"
               }
            }
         );
      }

      public int Activate(int id) {
         return _database.ExecuteNonQuery("ActivateUser_SP", CommandType.StoredProcedure, GetIdParameter(id));
      }

      public int Deactivate(int id) {
         return _database.ExecuteNonQuery("DeactivateUser_SP", CommandType.StoredProcedure, GetIdParameter(id));
      }
   }
}