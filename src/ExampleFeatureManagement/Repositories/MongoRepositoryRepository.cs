using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Helpers;
using Shared;
using Simple.Data;

namespace ExampleFeatureManagement.Repositories
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
            db[GetRepositoryName()].Insert(exampleFeatureInputModel);
        }

        private string GetRepositoryName()
        {
            return GetType().Name.Replace("Repository", string.Empty);
        }

        public void Update(T exampleFeatureInputModel)
        {
            var db = DatabaseFactory.GetMongoDatabase();
            db[GetRepositoryName()].UpdateById(exampleFeatureInputModel);
        }

        public IQueryable<T> GetAll()
        {
            var db = DatabaseFactory.GetMongoDatabase();
            var allItems = db[GetRepositoryName()].All().Cast<Models.ExampleFeatureInputModel>();
            return allItems.AsQueryable();
        }

        public T GetById(string id)
        {
            var db = DatabaseFactory.GetMongoDatabase();
            return (T)db[GetRepositoryName()].FindById(id);
        }

        public IEnumerable<T> GetPage(Bennington.Core.List.ListViewModel listViewModel)
        {
            var db = DatabaseFactory.GetMongoDatabase();
            if (listViewModel.SortBy == null)
                return db[GetRepositoryName()]
                    .All()
                    .Skip(listViewModel.PageIndex * listViewModel.PageSize)
                    .Take(listViewModel.PageSize)
                    .Cast<Models.ExampleFeatureInputModel>();

            var orderByDirection = listViewModel.SortDirection == SortDirection.Descending ? OrderByDirection.Descending : OrderByDirection.Ascending;

            var pagedSet = db[GetRepositoryName()]
                                .All()
                                .OrderBy(db[GetRepositoryName()][listViewModel.SortBy], orderByDirection)
                                .Skip(listViewModel.PageIndex*listViewModel.PageSize)
                                .Take(listViewModel.PageSize)
                                .Cast<Models.ExampleFeatureInputModel>();            
            return pagedSet;
        }

        public void Delete(string id)
        {
            var db = DatabaseFactory.GetMongoDatabase();
            db[GetRepositoryName()].DeleteById(id);
        }
    }
}
