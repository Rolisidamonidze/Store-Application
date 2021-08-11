using System;
using Store.Repositories;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Store.UnitTests {

   public abstract class BaseRepositoryTests<TModel, TRepo> where TModel: new() where TRepo : BaseRepository<TModel> {
      protected TModel _model;
      protected TRepo _repository;
      protected int _currentUserId;
      public BaseRepositoryTests(TModel model, TRepo repository) {
         _repository = repository;
         _model = model;
      }
      
      [Theory]
      [InlineData(1)]
      public virtual void InsertTest(int currentUserId) {
         int itemsCount = _repository.Select().Count();
         int expected = ++itemsCount;
         _repository.Insert(_model, currentUserId);

         var actual = _repository.Select().Count() ;

         Assert.Equal(expected, actual);
      }

      [Theory]
      [InlineData(1)]
      public virtual void UpdateTest(int currentUserId) {
         int expected = 0;
         int actual = _repository.Update(_model, currentUserId);

         Assert.Equal(expected, actual);
      }

      [Theory]
      [InlineData(1)]
      public virtual void DeleteTest(int currentUserId) {
         int expected = 0;
         int actual = _repository.Delete(_model, currentUserId);

         Assert.Equal(expected, actual);
      }

      [Fact]
      public virtual void SelectTest() {
         IEnumerable<TModel> actual = _repository.Select();
         Assert.NotNull(actual);
      }
   }
}
