using System;

namespace Store.Models {
   public class Product : BaseModel<int> {
      public short ProductCode { get; set; }
      public string Name { get; set; }
      public int CategoryID { get; set; }
      public decimal UnitPrice { get; set; }

      public override string ToString() {
         return Name;
      }
   }
}