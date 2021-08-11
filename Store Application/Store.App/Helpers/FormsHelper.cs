using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.App.Helpers {
   public static class FormsHelper {
      public static void AllowOnlyNumbers(object sender, KeyPressEventArgs e) {
         if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
            e.Handled = true;
         }

         if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) {
            e.Handled = true;
         }
      }
   }
}
