using ExampleFeatureManagement.Models;
using InputModelAggregateRoot.Repositories;

namespace ExampleFeatureManagement.Repositories
{
    public class ExampleFeaturesRepository : MongoRepository<ExampleFeatureInputModel>
    {
    }
}