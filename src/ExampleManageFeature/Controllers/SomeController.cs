using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bennington.Cms.Controllers;
using InputModelAggregateRoot;
using SampleCmsWebsite.Models;
using SimpleCqrs.Commanding;

namespace ExampleManageFeature.Controllers
{
    [ValidateInput(false)]
    public class SomeController : ListManageController<SomeForm, SomeForm>
    {
        private readonly ICommandBus commandBus;

        public SomeController(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        protected override IQueryable<SomeForm> GetListItems(Bennington.Core.List.ListViewModel listViewModel)
        {
            return GetAllSomeForms().AsQueryable();
        }

        public override ActionResult Create(SomeForm form)
        {
            commandBus.Send(new CreateInputModelCommand<SomeForm>()
                                {
                                    AggregateRootId = Guid.NewGuid(),
                                    InputModel = form,
                                    SecurityInformation = HttpContext.User.Identity.Name
                                });

            return base.Create(form);
        }

        public override void UpdateForm(SomeForm form)
        {
            commandBus.Send(new UpdateInputModelCommand<SomeForm>()
                                {
                                    AggregateRootId = new Guid(form.Id),
                                    InputModel = form,
                                    SecurityInformation = HttpContext.User.Identity.Name
                                });

            base.UpdateForm(form);
        }

        public override SomeForm GetFormById(object id)
        {
            return GetAllSomeForms().Where(a => a.Id == id.ToString()).FirstOrDefault();
        }

        private SomeForm[] GetAllSomeForms()
        {
            var list = new List<SomeForm>();
            list.Add(new SomeForm()
            {
                Id = "d15eac7d-a282-4b8c-a36d-92eebf82f3d5",
                Name = "test 1",
            });
            list.Add(new SomeForm()
            {
                Id = "38c04343-bc91-4896-8554-d844730b5a91",
                Name = "test 2",
            });

            return list.ToArray();
        }
    }
}
