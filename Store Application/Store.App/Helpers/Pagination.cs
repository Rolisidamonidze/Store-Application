using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.App.Helpers {
   public class Pagination<T> {
      public Pagination(IEnumerable<T> collection, int takeNumber = 10) {
         Collection = collection;
         TotalCount = Collection.Count();
         TakeNumber = takeNumber;
         CurrentChunk = Collection.Skip(SkipNumber).Take(TakeNumber);
      }

      public int TotalCount { get; set; }
      public int SkipNumber { get; set; } = 0;
      public int TakeNumber { get; set; }
      private IEnumerable<T> Collection { get; set; }
      public IEnumerable<T> CurrentChunk { get; set; }
      public bool HasNextRecords => SkipNumber < TotalCount;
      public bool HasPreviousRecords => SkipNumber > 0;

      public void UpdateCollection(IEnumerable<T> collection) {
         Collection = collection;
         TotalCount = Collection.Count();
         CurrentChunk = Collection.Skip(SkipNumber).Take(TakeNumber);
      }

      public IEnumerable<T> Next() {
         if (HasNextRecords) {
            SkipNumber += TakeNumber;
            CurrentChunk = Collection.Skip(SkipNumber).Take(TakeNumber);
         }
         return CurrentChunk;
      }

      public IEnumerable<T> Previous() {
         if (HasPreviousRecords) {
            SkipNumber -= TakeNumber;
            CurrentChunk = Collection.Skip(SkipNumber).Take(TakeNumber);
         }
         return CurrentChunk;
      }
   }
}
