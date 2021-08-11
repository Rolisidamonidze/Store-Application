using Store.App.Extensions;
using Store.Models;
using Store.Repositories;
using System;
using System.Windows.Forms;

namespace Store.App.EditForms {
   public partial class EmployeeEditForm : Form {
      Employee _employee;
      EmployeeRepository _employeeRepository;
      public EmployeeEditForm(Employee employee) {
         InitializeComponent();
         _employee = employee;
         _employeeRepository = new EmployeeRepository();
         FillFields();
      }

      private void btnConfirm_Click(object sender, EventArgs e) {
         var employeeToUpdate = new Employee
         {
            ID = _employee.ID,
            FirstName = txtFirstname.Text,
            LastName = txtLastname.Text,
            HomeAddress = txtAddress.Text,
            PersonalID = txtPersonalID.Text,
            Email = txtEmail.Text,
            Phone = txtPhone.Text,
            StartJob = dtpStartJob.Value,
            EndJob = dtpEndJob.Value
         };
         try {
            _employeeRepository.Update(employeeToUpdate, LocalStorage.CurrentUser.ID);
            this.Close();
         } catch (Exception err) {
            MessageBox.Show(err.Message);
         }
      }

      private void ckbxEndJob_CheckedChanged(object sender, EventArgs e) {
         dtpEndJob.Enabled = !dtpEndJob.Enabled;
      }

      private void FillFields() {
         txtFirstname.Text = _employee.FirstName;
         txtLastname.Text = _employee.LastName;
         txtAddress.Text = _employee.HomeAddress;
         txtPersonalID.Text = _employee.PersonalID;
         txtEmail.Text = _employee.Email;
         txtPhone.Text = _employee.Phone;
         dtpStartJob.Value = _employee.StartJob;
         dtpEndJob.Value = _employee.EndJob == null ? DateTime.Now : (DateTime)_employee.EndJob;
      }
   }
}
