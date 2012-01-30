using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using Shared;
using Simple.Data;

namespace InputModelAggregateRoot.Repositories
{
    public interface IRepository<T>
    {
        void Create(T exampleFeatureInputModel);
        void Update(T exampleFeatureInputModel);
        IQueryable<T> GetAll();
        T GetById(string id);
        IEnumerable<T> GetPage(Bennington.Core.List.ListViewModel listViewModel);
        void Delete(string id);
    }

    public class MongoRepository<T> : IRepository<T>
    {
        public void Create(T exampleFeatureInputModel)
        {
            var db = DatabaseFactory.GetMongoDatabase();
            db[GetCollectionName()].Insert(exampleFeatureInputModel);
        }

        public virtual string GetCollectionName()
        {
            return GetType().Name.Replace("Repository", string.Empty);
        }

        public void Update(T exampleFeatureInputModel)
        {
            var db = DatabaseFactory.GetMongoDatabase();
            db[GetCollectionName()].UpdateById(exampleFeatureInputModel);
        }

        public IQueryable<T> GetAll()
        {
            var db = DatabaseFactory.GetMongoDatabase();
            var allItems = db[GetCollectionName()].All().Cast<T>();
            return allItems.AsQueryable();
        }

        public T GetById(string id)
        {
            var db = DatabaseFactory.GetMongoDatabase();
            return (T)db[GetCollectionName()].FindById(id);
        }

        public IEnumerable<T> GetPage(Bennington.Core.List.ListViewModel listViewModel)
        {
            var db = DatabaseFactory.GetMongoDatabase();
            if (listViewModel.SortBy == null)
                return db[GetCollectionName()]
                    .All()
                    .Skip(listViewModel.PageIndex * listViewModel.PageSize)
                    .Take(listViewModel.PageSize)
                    .Cast<T>();

            var orderByDirection = listViewModel.SortDirection == SortDirection.Descending ? OrderByDirection.Descending : OrderByDirection.Ascending;

            var pagedSet = db[GetCollectionName()]
                                .All()
                                .OrderBy(db[GetCollectionName()][listViewModel.SortBy], orderByDirection)
                                .Skip(listViewModel.PageIndex*listViewModel.PageSize)
                                .Take(listViewModel.PageSize)
                                .Cast<T>();            
            return pagedSet;
        }

        public void Delete(string id)
        {
            var db = DatabaseFactory.GetMongoDatabase();
            db[GetCollectionName()].DeleteById(id);
        }
    }
}
