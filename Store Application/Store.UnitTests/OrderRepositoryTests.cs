using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Models;
using Store.Repositories;
using Xunit;

namespace Store.UnitTests {
   public class OrderRepositoryTests : BaseRepositoryTests<Order, Repositories.OrderDetail> {
      public OrderRepositoryTests() : base(Order, OrderRepository) {

      }

      public static Order Order => new()
      {
         ID = 1,
         UserID = 1,
         OrderDate = new DateTime(2004, 12, 15)
      };

      public static Repositories.OrderDetail OrderRepository => new Repositories.OrderDetail();
   }
}
