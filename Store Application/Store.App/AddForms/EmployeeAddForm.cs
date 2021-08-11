using Store.App.Extensions;
using Store.Models;
using Store.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.App.AddForms {
   public partial class EmployeeAddForm : Form {
      EmployeeRepository _employeeRepository;
      public EmployeeAddForm() {
         InitializeComponent();

         MdiParent = LocalStorage.MainForm;
         _employeeRepository = new();

#if DEBUG
         txtFirstName.Text = "Shako";
         txtLastName.Text = "Kalabegashvili";
         txtPersonalID.Text = "43821237863";
         txtPhone.Text = "599543421";
         txtEmail.Text = "shakokalabegashvili@gmail.com";
         txtHomeAddress.Text = "Ortachala Street 1";
         dtpStartJob.Value = new DateTime(2020, 01, 01);
#endif
      }

      private void ckbxEndJob_CheckedChanged(object sender, EventArgs e) {
         dtpEndJob.Enabled = !dtpEndJob.Enabled;
      }

      private void btnSubmit_Click(object sender, EventArgs e) {
         Employee employee = new Employee
         {
            FirstName = txtFirstName.Text,
            LastName = txtLastName.Text,
            PersonalID = txtPersonalID.Text,
            HomeAddress = txtHomeAddress.Text,
            Phone = txtPhone.Text,
            Email = txtEmail.Text,
            StartJob = dtpStartJob.Value,
            EndJob = dtpEndJob.Enabled ? dtpEndJob.Value : null,
         };

         try {
            _employeeRepository.Insert(employee, LocalStorage.CurrentUser.ID);
            this.Close();
         } catch (Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }
   }
}
