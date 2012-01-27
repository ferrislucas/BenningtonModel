using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bennington.Cms.Controllers;
using ExampleFeatureManagement.Models;
using ExampleFeatureManagement.Repositories;
using InputModelAggregateRoot;
using InputModelAggregateRoot.Commands;
using Omu.ValueInjecter;
using SimpleCqrs.Commanding;

namespace ExampleFeatureManagement.Controllers
{
    [ValidateInput(false)]
    public class ExampleFeatureManagementController : ListManageController<ExampleFeatureListViewModel, ExampleFeatureInputModel>
    {
        private readonly ICommandBus commandBus;
        private readonly IExampleFeatureRepository exampleFeatureRepository;

        public ExampleFeatureManagementController(ICommandBus commandBus, 
                                                  IExampleFeatureRepository exampleFeatureRepository)
        {
            this.exampleFeatureRepository = exampleFeatureRepository;
            this.commandBus = commandBus;
        }

        protected override IQueryable<ExampleFeatureListViewModel> GetListItems(Bennington.Core.List.ListViewModel listViewModel)
        {
            return (
                    from item in exampleFeatureRepository.GetPage(listViewModel)
                    select ((ExampleFeatureListViewModel) new ExampleFeatureListViewModel().InjectFrom(item))
                    ).AsQueryable();
        }

        public override ExampleFeatureInputModel GetFormById(object id)
        {
            return exampleFeatureRepository.GetById(id.ToString());
        }

        protected override ExampleFeatureInputModel CreateForm()
        {
            return new ExampleFeatureInputModel()
                       {
                           Id = Guid.NewGuid().ToString(),
                       };
        }

        public override void InsertForm(ExampleFeatureInputModel form)
        {
            form.CreateDate = DateTime.Now;
            form.CreateBy = HttpContext.User.Identity.Name;
            form.LastModifyBy = form.CreateBy;
            form.LastModifyDate = form.CreateDate;
            commandBus.Send(new CreateInputModelCommand()
                                    {
                                        AggregateRootId = new Guid(form.Id),
                                        InputModel = form,
                                        SecurityInformation = HttpContext.User.Identity.Name
                                    });

            base.InsertForm(form);
        }

        public override void UpdateForm(ExampleFeatureInputModel form)
        {
            form.LastModifyDate = DateTime.Now;
            form.LastModifyBy = HttpContext.User.Identity.Name;
            commandBus.Send(new UpdateInputModelCommand()
                                {
                                    AggregateRootId = new Guid(form.Id),
                                    InputModel = form,
                                    SecurityInformation = HttpContext.User.Identity.Name
                                });

            base.UpdateForm(form);
        }

        public override ActionResult Delete(object id)
        {
            commandBus.Send(new DeleteInputModelCommand()
                                {
                                    AggregateRootId = (Guid) GetIdForDelete(id),
                                    InputModelType = typeof(ExampleFeatureInputModel),
                                    SecurityInformation = HttpContext.User.Identity.Name,
                                });
            return base.Delete(id);
        }

        private static Guid? GetIdForDelete(object id)
        {
            var idToUse = id as string;
            if (idToUse == null)
            {
                var idArray = id as string[];
                if (idArray == null) return null;
                idToUse = idArray.FirstOrDefault();
            }
            return new Guid(idToUse);
        }
    }
}
