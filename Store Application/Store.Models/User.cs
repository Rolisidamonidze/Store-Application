using System;
using System.Data;
using System.Data.Common;
using Store.Models;

namespace Store.Models {
   public class User : BaseModel<int> {
      public string Username { get; set; }
      public string Password { get; set; }

      public override string ToString() {
         return Username;
      }
   }
}
