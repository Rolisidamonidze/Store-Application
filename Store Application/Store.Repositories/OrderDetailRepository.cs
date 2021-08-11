using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repositories {
   public class OrderDetailRepository: BaseRepository<OrderDetail> {
      public OrderDetailRepository() : base() {

      }

      public override int Update(OrderDetail model, int userId) {
         throw new NotSupportedException("Update method is not available in OrderDetailsRepository");
      }

      public override int Delete(OrderDetail model, int userId) {
         throw new NotSupportedException("Delete method is not available in OrderDetailsRepository");
      }
   }
}