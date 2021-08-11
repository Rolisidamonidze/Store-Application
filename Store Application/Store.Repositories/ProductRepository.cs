using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories {
   public class ProductRepository: BaseRepository<Product> {
      public ProductRepository() : base() {
      }
   }
}
