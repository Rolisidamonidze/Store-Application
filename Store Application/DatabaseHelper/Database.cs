using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatabaseHelper {
   public abstract class Database : IDisposable {
      public abstract IDbConnection GetConnection();
      public abstract void OpenConnection();
      public abstract IDbCommand GetCommand(string commandText, CommandType commandType);
      public abstract IDbCommand GetCommand(string commandText, params IDbDataParameter[] parameters);
      public abstract IDbCommand GetCommand(string commandText, CommandType commandType, params IDbDataParameter[] parameters);
      public abstract int ExecuteNonQuery(string commandText, params IDbDataParameter[] parameters);
      public abstract int ExecuteNonQuery(string commandText, CommandType commandType, params IDbDataParameter[] parameters);
      public abstract object ExecuteScalar(string commandText, CommandType commandType, params IDbDataParameter[] parameters);
      public abstract IDataReader ExecuteReader(string commandText);
      public abstract IDataReader ExecuteReader(string commandText, CommandType commandType);
      public abstract IDataReader ExecuteReader(string commandText, CommandType commandType, params IDbDataParameter[] parameters);
      public abstract DataTable GetDataTable(string commandText);
      public abstract DataTable GetDataTable(string commandText, CommandType commandType, params IDbDataParameter[] parameters);
      public abstract IDbTransaction BeginTransaction();
      public abstract void CommitTransaction();
      public abstract void RollbackTransaction();
      public abstract void Dispose();
      public abstract bool ConnectionExists();
      public abstract bool IsSingleTone();
      public abstract bool IsNotDisposed();
      public abstract void ShareTransaction(IDbTransaction transaction);
   }
}
