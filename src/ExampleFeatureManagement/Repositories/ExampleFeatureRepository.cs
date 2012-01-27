using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared;

namespace ExampleFeatureManagement.Repositories
{
    public interface IExampleFeatureRepository
    {
        void Create(Models.ExampleFeatureInputModel exampleFeatureInputModel);
        void Update(Models.ExampleFeatureInputModel exampleFeatureInputModel);
        IQueryable<Models.ExampleFeatureInputModel> GetAll();
        Models.ExampleFeatureInputModel GetById(string id);
        IEnumerable<Models.ExampleFeatureInputModel> GetPage(int pageIndex, int itemsPerPage);
        void Delete(string id);
    }

    public class ExampleFeatureRepository : IExampleFeatureRepository
    {
        public void Create(Models.ExampleFeatureInputModel exampleFeatureInputModel)
        {
            var db = DatabaseFactory.GetMongoDatabase();
            db.ExampleFeatures.Insert(exampleFeatureInputModel);
        }

        public void Update(Models.ExampleFeatureInputModel exampleFeatureInputModel)
        {
            var db = DatabaseFactory.GetMongoDatabase();
            db.ExampleFeatures.UpdateById(exampleFeatureInputModel);
        }

        public IQueryable<Models.ExampleFeatureInputModel> GetAll()
        {
            var db = DatabaseFactory.GetMongoDatabase();
            var allItems = db.ExampleFeatures.All().Cast<Models.ExampleFeatureInputModel>();
            return allItems.AsQueryable();
        }

        public Models.ExampleFeatureInputModel GetById(string id)
        {
            var db = DatabaseFactory.GetMongoDatabase();
            return (Models.ExampleFeatureInputModel) db.ExampleFeatures.FindById(id);
        }

        public IEnumerable<Models.ExampleFeatureInputModel> GetPage(int pageIndex, int itemsPerPage)
        {
            var db = DatabaseFactory.GetMongoDatabase();
            var pagedSet = db.ExampleFeatures
                                .All()
                                .Skip(pageIndex * itemsPerPage)
                                .Take(itemsPerPage)
                                .Cast<Models.ExampleFeatureInputModel>();
            return pagedSet;
        }

        public void Delete(string id)
        {
            var db = DatabaseFactory.GetMongoDatabase();
            db.ExampleFeatures.DeleteById(id);
        }
    }
}
