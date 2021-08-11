using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models {
   public class ProductDetail : BaseModel<int> {
      public int Quantity { get; set; }
      public DateTime ExpirationDate { get; set; }
   }
}
