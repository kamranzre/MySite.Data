using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using MySite.Data.DataBaseContext;
using MySite.Data.Infrastructure;
using MySite.Entity.Entities.Persons;
using MySite.Entity.Models.PersonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCRUD.Controllers
{
    public class PersonController : Controller
    {
        private readonly UnitOfWork<MySiteDbContext> _repository;
        public PersonController(UnitOfWork<MySiteDbContext> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {

            return View();
        }
        public async Task<IActionResult> Peson_Read([DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<PersonCreateOrEditModel> model = await _repository.PersonRepository.GetPrunedData();
            DataSourceResult result = model.ToDataSourceResult(request);

            return Json(result);
        }
        public async Task<IActionResult> Create()
        {
            PersonCreateOrEditModel model = new PersonCreateOrEditModel();
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonCreateOrEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var Export = _repository.PersonRepository.AddAsynce(model);
                    if (Export)
                    {

                        return Json(true);

                    }
                    else
                        return Json(false);
                }
                return Json(false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
                return NotFound();
            var model = _repository.PersonRepository.GetItem(x => x.Id == id.Value);
            PersonCreateOrEditModel personmodel = new PersonCreateOrEditModel() { Name = model.Name, FName = model.FName, NationalCode = model.NationalCode, PhoneNumber = model.PhoneNumber };
            if (model == null)
                return NotFound();
            return PartialView(personmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long? id, PersonCreateOrEditModel model)
        {
            try
            {
                if (id != model.Id)
                    return NotFound();
                if (ModelState.IsValid)
                {
                    var edit = _repository.PersonRepository.Edit(model);
                    if (edit)
                        return Json(true);
                    return Json(false);
                }
                return Json(false);
            }
            catch (Exception ex)
            {

                return Json(false);
            }

        }

       [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteitem =  _repository.PersonRepository.DeleteAsynce(id);
            return Json(deleteitem);
        }


    }
}
