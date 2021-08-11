using System;
using System.Data.SqlClient;
using System.Data;

namespace DatabaseHelper {
   public class SqlDatabase : Database {
      private bool _isSingletone;
      private string _connectionString;
      private bool _isDisposed;
      private SqlConnection _connection;
      private SqlTransaction _transaction;
      private bool _isTransactionOn;

      public SqlDatabase(string connectionString, bool useSingleton) {
         _connectionString = connectionString;
         _isSingletone = useSingleton;
         _isDisposed = false;
      }

      public override SqlConnection GetConnection() {
         IsNotDisposed();

         if (_connection == null || !_isSingletone) {
            _connection = new SqlConnection(_connectionString);
         }
         return _connection;
      }

      public override void OpenConnection() {
         var connection = GetConnection();
         if (connection.State == ConnectionState.Closed) {
            connection.Open();
         }
      }

      public override SqlCommand GetCommand(string commandText, CommandType commandType) {
         var command = GetConnection().CreateCommand();
         command.Transaction = _transaction;
         command.CommandText = commandText;
         command.CommandType = commandType;
         return command;
      }

      public override SqlCommand GetCommand(string commandText, params IDbDataParameter[] parameters) {
         return GetCommand(commandText, CommandType.Text, parameters);
      }

      public override SqlCommand GetCommand(string commandText, CommandType commandType, params IDbDataParameter[] parameters) {
         var command = GetConnection().CreateCommand();
         command.Transaction = _transaction;
         command.CommandText = commandText;
         command.CommandType = commandType;
         command.Parameters.AddRange(parameters);
         return command;
      }

      public override int ExecuteNonQuery(string commandText, params IDbDataParameter[] parameters) {
         var command = GetCommand(commandText, parameters);
         try {
            OpenConnection();
            return command.ExecuteNonQuery();
         } catch {
            throw;
         } finally {
            if (!_isTransactionOn) {
               command.Connection.Close();
            }
         }
      }

      public override int ExecuteNonQuery(string commandText, CommandType commandType, params IDbDataParameter[] parameters) {
         var command = GetCommand(commandText, commandType, parameters);
         try {
            OpenConnection();
            return command.ExecuteNonQuery();
         } catch {
            throw;
         } finally {
            if (!_isTransactionOn) {
               command.Connection.Close();
            }
         }
      }

      public override object ExecuteScalar(string commandText, CommandType commandType, params IDbDataParameter[] parameters) {
         object result;
         var command = GetCommand(commandText, commandType, parameters);
         try {
            OpenConnection();
            result = command.ExecuteScalar();
            return result;
         } catch {
            throw;
         } finally {
            if (!_isTransactionOn) {
               command.Connection.Close();
            }
         }
      }

      public override SqlDataReader ExecuteReader(string commandText, CommandType commandType, params IDbDataParameter[] parameters) {
         var command = GetCommand(commandText, commandType, parameters);
         try {
            OpenConnection();
            return _isTransactionOn ?
                   command.ExecuteReader() :
                   command.ExecuteReader(CommandBehavior.CloseConnection);
         } catch {
            throw;
         }
      }

      public override SqlDataReader ExecuteReader(string commandText, CommandType commandType) {
         var command = GetCommand(commandText, commandType);
         try {
            OpenConnection();
            return _isTransactionOn ?
                   command.ExecuteReader() :
                   command.ExecuteReader(CommandBehavior.CloseConnection);
         } catch {
            throw;
         }
      }

      public override SqlDataReader ExecuteReader(string commandText) {
         var command = GetCommand(commandText, CommandType.Text);
         try {
            OpenConnection();
            return _isTransactionOn ?
                   command.ExecuteReader() :
                   command.ExecuteReader(CommandBehavior.CloseConnection);
         } catch {
            throw;
         }
      }

      public override DataTable GetDataTable(string commandText) {
         DataTable dataTable = new DataTable();
         SqlDataReader reader = ExecuteReader(commandText);
         dataTable.Load(reader);
         reader.Close();
         return dataTable;
      }

      public override DataTable GetDataTable(string commandText, CommandType commandType, params IDbDataParameter[] parameters) {
         DataTable dataTable = new DataTable();
         SqlDataReader reader = ExecuteReader(commandText, commandType, parameters);
         dataTable.Load(reader);
         reader.Close();
         return dataTable;
      }

      public override SqlTransaction BeginTransaction() {
         IsSingleTone();
         IsNotDisposed();
         OpenConnection();

         if (_transaction == null) {
            _transaction = _connection.BeginTransaction();
         }

         _isTransactionOn = true;
         return _transaction;
      }

      public override void CommitTransaction() {
         IsNotDisposed();
         ConnectionExists();
         _transaction?.Commit();
         _connection?.Close();
         _isTransactionOn = false;
      }

      public override void RollbackTransaction() {
         IsNotDisposed();
         ConnectionExists();
         _transaction?.Rollback();
         _connection?.Close();
         _isTransactionOn = false;
         _transaction = null;
      }

      public override void ShareTransaction(IDbTransaction transaction) {
         _transaction = (SqlTransaction)transaction;
         _isTransactionOn = true;
         _connection = _transaction.Connection;
      }

      public override void Dispose() {
         _connection?.Close();
         _transaction?.Dispose();
         _connection?.Dispose();
         _isDisposed = true;
         _isTransactionOn = false;
      }

      public override bool ConnectionExists() {
         if (_connection == null) throw new Exception("Connection doesn't exist.");
         return true;
      }

      public override bool IsSingleTone() {
         if (!_isSingletone)
            throw new Exception("Transaction is only supported in SingleToneMode");
         return true;
      }

      public override bool IsNotDisposed() {
         if (_isDisposed) throw new ObjectDisposedException("Object is disposed.");
         return true;
      }
   }
}