using Bennington.Cms.InputModelAggregateRoot.Repositories;
using ExampleFeature.Cms.Models;

namespace ExampleFeature.Cms.Repositories
{
    public class ExampleFeaturesRepository : MongoRepository<ExampleFeatureInputModel>
    {
    }
}