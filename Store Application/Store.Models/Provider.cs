using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models {
   public class Provider : BaseModel<int> {
      public string Name { get; set; }
      public string Phone { get; set; }
      public string Email { get; set; }

      public override string ToString() {
         return Name;
      }
   }
}
