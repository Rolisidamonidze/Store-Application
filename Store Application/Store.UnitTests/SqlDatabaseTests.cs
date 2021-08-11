using DatabaseHelper;
using System;
using Xunit;

namespace Store.UnitTests {
   public class SqlDatabaseTests {
      string _connectionString = @"server =.\sqlexpress; database = Market; integrated security = true";

      [Theory]
      [InlineData(true)]
      [InlineData(false)]
      public void GetConnectionTest(bool isSingleTone) {
         SqlDatabase database = new SqlDatabase(_connectionString, isSingleTone);

         var connection1 = database.GetConnection();
         var connection2 = database.GetConnection();

         if (isSingleTone) {
            Assert.Equal(connection1, connection2);
         } else {
            Assert.NotEqual(connection1, connection2);
         }
      }

      [Theory]
      [InlineData(true)]
      [InlineData(false)]
      public void OpenConnectionTest(bool isSingleTone) {
         SqlDatabase database = new SqlDatabase(_connectionString, isSingleTone);
         database.GetConnection();
         database.OpenConnection();

         Assert.Throws<InvalidOperationException>(() => database.OpenConnection());
      }

      [Theory]
      [InlineData(true)]
      [InlineData(false)]
      public void DisposeTest(bool isSingleTone) {
         SqlDatabase database = new SqlDatabase(_connectionString, isSingleTone);

         database.Dispose();

         Assert.Throws<ObjectDisposedException>(() => database.IsNotDisposed());
      }

      [Theory]
      [InlineData(true)]
      [InlineData(false)]
      public void IsNotDisposedTest(bool isSingleTone) {
         SqlDatabase database = new SqlDatabase(_connectionString, isSingleTone);
         Assert.True(database.IsNotDisposed());
      }
   }
}
