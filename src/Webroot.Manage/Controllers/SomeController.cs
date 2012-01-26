using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bennington.Cms.Controllers;
using SampleCmsWebsite.Models;

namespace SampleCmsWebsite.Controllers
{
    public class SomeController : ListManageController<SomeForm, SomeForm>
    {
        protected override IQueryable<SomeForm> GetListItems(Bennington.Core.List.ListViewModel listViewModel)
        {
            return GetAllSomeForms().AsQueryable();
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
                Id = "1",
                Name = "test 1",
            });
            list.Add(new SomeForm()
            {
                Id = "2",
                Name = "test 2",
            });

            return list.ToArray();
        }
    }
}
