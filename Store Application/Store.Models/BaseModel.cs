using System;
using Store.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models {
   public class BaseModel<TType> : IIdentity<TType> {
      public TType ID { get; set; }
   }
}
