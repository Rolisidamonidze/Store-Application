using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repositories {
   public class PurchaseDetailRepository : BaseRepository<PurchaseDetail>{
      public PurchaseDetailRepository(): base() {

      }

      public override int Update(PurchaseDetail model, int userId) {
         throw new NotSupportedException("Update method is not available in purchaseDetial repsoitory");
      }

      public override int Delete(PurchaseDetail model, int userId) {
         throw new NotSupportedException("Delete method is not available in purchaseDetial repsoitory");
      }
   }
}
