using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models {
   public class Purchase : BaseModel<int> {
      public int ProviderID { get; set; }
      public int UserID { get; set; }
      public DateTime RequiredDate { get; set; }
   }
}
