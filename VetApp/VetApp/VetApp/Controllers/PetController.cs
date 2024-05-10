using Microsoft.AspNetCore.Mvc;
using VetApp.Entities;
using VetApp.Models;
using VetApp.Services;

namespace VetApp.Controllers
{
	[FilterSecurity]
	[ResponseCache(NoStore = true, Duration = 0)]
	public class PetController : Controller
    {
		private readonly IConfiguration _configuration;
		private readonly PetModel _petModel;
        public List<PetObj> _petsList;

		public PetController(IConfiguration configuration)
        {
            _configuration = configuration;
            _petModel = new PetModel(configuration);
            _petsList = _petModel.GetPets();
        }

        public IActionResult Pet(int idClient = 0)
        {
            if(idClient == 0)
            {
				//ViewBag.Pets = _petsList;

                return RedirectToAction("Client","Client");
            }
            else
            {
                ViewBag.Pets = _petModel.GetPetsByClient(idClient);
                //_petsList.Where(data => data.idClient == idClient).ToList();
                //
                ViewBag.IdClient = idClient;

			}
            
            return View();
        }

        public IActionResult AgregarMascota()
        {
            return View();
        }

        public IActionResult Mascota()
        {
            return View();
        }

        public IActionResult EditarMascota()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreatePet(PetObj petObj)
        {
            var createPet = _petModel.CreatePet(petObj);
            return Json(createPet);
        }

        [HttpGet]
        public JsonResult GetPet(int idPet)
        {
            var pet = _petsList.Where(data => data.IdPet == idPet).FirstOrDefault();
            return Json(pet);
        }

        [HttpPut]
        public JsonResult UpdatePet(PetObj petObj)
        {
            var updatePet = _petModel.UpdatePet(petObj);
            return Json(updatePet);
        }

        [HttpDelete]
        public JsonResult DeletePet(int idPet)
        {
            var deletePet = _petModel.DeletePet(idPet);
            return Json(deletePet);
        }
    }
}
