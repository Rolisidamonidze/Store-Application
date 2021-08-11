using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.App {
   public static class LocalStorage {
      public static User CurrentUser { get; set; }
      public static List<int> Permissions { get; set; }
      public static Form MainForm { get; set; }
   }
}
