using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models {
   public class Order : BaseModel<int> {
      public int UserID { get; set; }
      public DateTime OrderDate { get; set; }
   }
}
