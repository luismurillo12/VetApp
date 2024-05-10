using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetAppApi.Entities;
using VetAppApi.Models;

namespace VetAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private PetModel _petModel;

        public PetController(PetModel petModel)
        {
            _petModel = petModel;
        }

        [HttpPost]
        [Route("CreatePet")]
        public ActionResult<int> CreatePet(PetObj petObj)
        {
            return _petModel.CreatePet(petObj);
        }

        [HttpGet]
        [Route("GetPets")]
        public ActionResult<IEnumerable<PetObj>> GetPets()
        {
            return _petModel.GetPets().ToList();
        }

        [HttpPut]
        [Route("UpdatePet")]
        public ActionResult<int> UpdatePet(PetObj petObj)
        {
            return _petModel.UpdatePet(petObj);
        }

        [HttpDelete]
        [Route("DeletePet")]
        public ActionResult<int> DeletePet(int idPet)
        {
            return _petModel.DeletePet(idPet);
        }

		[HttpGet("GetPetsByClient/{idClient}")]
		public ActionResult<List<PetObj>> GetPetsByClient(int idClient)
		{
			try
			{
				var pets = _petModel.GetPetsByClient(idClient);
				return pets != null ? pets : NotFound();
			}
			catch (Exception ex)
			{
				return StatusCode(500, "An error occurred while fetching reviews." + ex.Message);
			}
		}
	}
}
