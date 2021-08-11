using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models {
   public class Employee : BaseModel<int> {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string PersonalID { get; set; }
      public string Phone { get; set; }
      public string Email { get; set; }
      public string HomeAddress { get; set; }
      public DateTime StartJob { get; set; }
      public DateTime? EndJob { get; set; }

      public override string ToString() {
         return FirstName + " " + LastName;
      }
   }
}
