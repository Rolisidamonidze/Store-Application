using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repositories {
   public class PurchaseRepository: BaseRepository<Purchase> {
      public PurchaseRepository(): base() {
            
      }

      public override int Update(Purchase model, int userId) {
         throw new NotSupportedException("Update method is not available in purchase repsoitory");
      }

      public override int Delete(Purchase model, int userId) {
         throw new NotSupportedException("Delete method is not available in purchase repsoitory");
      }
   }
}
