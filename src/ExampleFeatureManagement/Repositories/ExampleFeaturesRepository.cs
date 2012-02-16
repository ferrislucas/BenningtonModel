using Bennington.Cms.InputModelAggregateRoot.Repositories;
using ExampleFeatureManagement.Models;

namespace ExampleFeatureManagement.Repositories
{
    public class ExampleFeaturesRepository : MongoRepository<ExampleFeatureInputModel>
    {
    }
}