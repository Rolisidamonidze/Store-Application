using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models {
   public class OrderDetail : BaseModel<int> {
      public int ProductID { get; set; }
      public short Quantity { get; set; }
      public decimal UnitPrice { get; set; }
      public double Discount { get; set; }
   }
}
