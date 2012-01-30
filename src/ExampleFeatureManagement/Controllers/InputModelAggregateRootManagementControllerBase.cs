using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using Bennington.Cms.Controllers;
using ExampleFeatureManagement.Models;
using ExampleFeatureManagement.Repositories;
using InputModelAggregateRoot.Commands;
using Omu.ValueInjecter;
using SimpleCqrs.Commanding;

namespace ExampleFeatureManagement.Controllers
{
    [ValidateInput(false)]
    public class InputModelAggregateRootManagementControllerBase<TListViewModel, TInputModel> : ListManageController<TListViewModel, TInputModel>
    {
        private readonly ICommandBus commandBus;
        private readonly IRepository<TInputModel> repository;

        public InputModelAggregateRootManagementControllerBase(ICommandBus commandBus, 
                                                  IRepository<TInputModel> repository)
        {
            this.repository = repository;
            this.commandBus = commandBus;
        }

        protected override IQueryable<TListViewModel> GetListItems(Bennington.Core.List.ListViewModel listViewModel)
        {
            var list = new List<TListViewModel>();
            foreach (var item in repository.GetPage(listViewModel))
            {
                var instance = Activator.CreateInstance(typeof(TListViewModel));
                instance.InjectFrom(item);
                list.Add((TListViewModel) instance);
            }
            return list.AsQueryable();
        }

        public override TInputModel GetFormById(object id)
        {
            return repository.GetById(id.ToString());
        }

        protected override TInputModel CreateForm()
        {
            var instance = Activator.CreateInstance(typeof (TInputModel));
            var idPropertyInfo = typeof(TInputModel).GetProperty("Id");
            idPropertyInfo.SetValue(instance, Guid.NewGuid().ToString(), null);

            return (TInputModel) instance;
        }

        public override void InsertForm(TInputModel form)
        {
            var propertyInfo = typeof(TInputModel).GetProperty("CreateDate");
            propertyInfo.SetValue(form, DateTime.Now, null);

            propertyInfo = typeof(TInputModel).GetProperty("CreateBy");
            propertyInfo.SetValue(form, HttpContext.User.Identity.Name, null);

            propertyInfo = typeof(TInputModel).GetProperty("LastModifyBy");
            propertyInfo.SetValue(form, HttpContext.User.Identity.Name, null);

            propertyInfo = typeof(TInputModel).GetProperty("LastModifyDate");
            propertyInfo.SetValue(form, DateTime.Now, null);

            propertyInfo = typeof(TInputModel).GetProperty("Id");
            var id = propertyInfo.GetValue(form, null);

            commandBus.Send(new CreateInputModelCommand()
                                    {
                                        AggregateRootId = new Guid(id.ToString()),
                                        InputModel = form,
                                        SecurityInformation = HttpContext.User.Identity.Name
                                    });

            base.InsertForm(form);
        }

        public override void UpdateForm(TInputModel form)
        {
            var propertyInfo = typeof(TInputModel).GetProperty("LastModifyBy");
            propertyInfo.SetValue(form, HttpContext.User.Identity.Name, null);

            propertyInfo = typeof(TInputModel).GetProperty("LastModifyDate");
            propertyInfo.SetValue(form, DateTime.Now, null);

            propertyInfo = typeof(TInputModel).GetProperty("Id");
            var id = propertyInfo.GetValue(form, null);

            commandBus.Send(new UpdateInputModelCommand()
                                {
                                    AggregateRootId = new Guid(id.ToString()),
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
                                    InputModelType = typeof(TInputModel),
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
