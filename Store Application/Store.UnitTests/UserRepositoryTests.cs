using Store.Models;
using Store.Repositories;
using System;

namespace Store.UnitTests {
   public class UserRepositoryTests: BaseRepositoryTests<User, UserRepository>{
      public UserRepositoryTests() : base(User, UserRepository) {
            
      }

      static User User => new User()
      {
         ID = 10,
         Username = "ZuraChachava",
         Password = "zuka123"
      };

      static UserRepository UserRepository => new UserRepository();
   }
}
