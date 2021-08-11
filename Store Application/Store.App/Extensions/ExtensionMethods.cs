using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.App.Extensions {
   public static class ExtensionMethods {
      #region Permissions
      public static bool HasPermission(this ToolStripDropDownItem item) {
         string controlPermissions = ((string)item.Tag);

         if (item.Tag == null || (string)item.Tag == "") {
            return true;
         }
         foreach (string controlPermission in controlPermissions.Split(',')) {
            if (LocalStorage.Permissions.Contains(int.Parse(controlPermission))) {
               return true;
            }
         }
         return false;
      }

      public static bool HasPermission(this Control control) {
         string controlPermissions = ((string)control.Tag);

         if (control.Tag == null) {
            return true;
         }
         foreach (string controlPermission in controlPermissions.Split(',')) {
            if (LocalStorage.Permissions.Contains(int.Parse(controlPermission))) {
               return true;
            }
         }
         return false;
      }
      #endregion

      #region Forms

      public static bool HasMdiChildForm(this Form form, string childFormName) {
         foreach (Form child in form.MdiChildren) {
            if(child.Name == childFormName) {
               return true;
            }
         }

         return false;
      }

      public static Form GetMdiChildForm(this Form form, string childFormName) {
         foreach (Form child in form.MdiChildren) {
            if (child.Name == childFormName) {
               return child;
            }
         }

         return null;
      }

      #endregion
   }
}
