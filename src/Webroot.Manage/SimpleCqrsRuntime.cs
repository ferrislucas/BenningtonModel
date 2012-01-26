using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Bennington.ContentTree.Denormalizers;
using Bennington.ContentTree.Providers.ContentNodeProvider.Denormalizers;
using Bennington.ContentTree.Providers.SectionNodeProvider.Denormalizers;
using ExampleManageFeature.Controllers;
using InputModelAggregateRoot;
using Microsoft.Practices.Unity;
using SimpleCqrs;

namespace SampleCmsWebsite
{
    public class SimpleCqrsRuntime : SimpleCqrsRuntime<SimpleCqrs.Unity.UnityServiceLocator>
    {
        private readonly UnityContainer serviceLocator;

        public SimpleCqrsRuntime(UnityContainer serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        protected override IEnumerable<Assembly> GetAssembliesToScan(IServiceLocator simpleCqrsServiceLocator)
        {
            var assemblies = new List<Assembly>
                                {
                                    Assembly.GetAssembly(typeof(Bennington.ContentTree.Domain.CommandHandlers.CreatePageCommandHandler)),
                                    Assembly.GetAssembly(typeof (TreeNodeDenormalizer)),
                                    Assembly.GetAssembly(typeof (ContentNodeProviderDraftDenormalizer)),
                                    Assembly.GetAssembly(typeof(SectionNodeProviderDraftDenormalizer)),

                                    Assembly.GetAssembly(typeof(CreateInputModelCommand)),
                                };

            assemblies.AddRange((base.GetAssembliesToScan(simpleCqrsServiceLocator)));

            return assemblies;
        }
    }
}