using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models {
   public class PurchaseDetail : BaseModel<int> {
      public int ProductID { get; set; }
      public decimal UnitPrice { get; set; }
      public short Quantity { get; set; }
      public DateTime StoreDate { get; set; }
      public DateTime ExpirationDate { get; set; }
   }
}
