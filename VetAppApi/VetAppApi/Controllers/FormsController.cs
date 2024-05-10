using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetAppApi.Entities;
using VetAppApi.Models;

namespace VetAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormsController : ControllerBase
    {
        private FormsModel _formsModel;

        public FormsController(FormsModel formsModel)
        {
            _formsModel = formsModel;
        }

        [HttpPost]
        [Route("CreateForms")]
        public ActionResult<int> CreateForms(FormsObj formsObj)
        {
            return _formsModel.CreateForms(formsObj);
        }

        [HttpGet]
        [Route("GetFormsForCurrentDay")]
        public ActionResult<IEnumerable<FormsListObj>> GetFormsForCurrentDay()
        {
            return _formsModel.GetFormsForCurrentDay().ToList();
        }

        [HttpGet]
        [Route("GetAllForms")]
        public ActionResult<IEnumerable<FormsListObj>> GetAllForms()
        {
            return _formsModel.GetAllForms().ToList();
        }

        [HttpPut]
        [Route("UpdateForms")]
        public ActionResult<int> UpdateForms(FormsObj formsObj)
        {
            return _formsModel.UpdateForms(formsObj);
        }

        [HttpDelete]
        [Route("DeleteForms")]
        public ActionResult<int> DeleteForms(int idForms)
        {
            return _formsModel.DeleteForms(idForms);
        }

        [HttpGet]
        [Route("GetForms")]
        public ActionResult<IEnumerable<FormsListObj>> GetForms()
        {
            return _formsModel.GetForms().ToList();
        }

    }
}