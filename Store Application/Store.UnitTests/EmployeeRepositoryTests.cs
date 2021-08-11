using Store.Models;
using Store.Repositories;
using System;
using Xunit;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Store.UnitTests {
   public class EmployeeRepositoryTests : BaseRepositoryTests<Employee, EmployeeRepository> {

      public EmployeeRepositoryTests() : base(Employee, EmployeeRepository) { 
      }

      static Employee Employee => new Employee()
      {
         ID = 10,
         FirstName = "Akaki",
         LastName = "Zautashvili",
         PersonalID = "97465374653",
         Email = "akakizautashvili@gmail.com",
         HomeAddress = "Tbilisi Oqros Ubani",
         Phone = "598452312",
         StartJob = new DateTime(2019, 03, 24),
         EndJob = null,
      };

      static EmployeeRepository EmployeeRepository => new EmployeeRepository();
   }
}
