using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models {
   public interface IIdentity<T> {
      T ID { get; set; }
   }
}
