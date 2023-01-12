using ClinicService.Models.Requests;
using ClinicService.Models;
using ClinicService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Api.V2.Controllers
{
    [ApiController]
    //[ApiVersion("2.0")]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpPost("create")]
        public ActionResult<int> Create([FromBody] CreatePetRequest createRequest)
        {
            int res = _petRepository.Create(new Pet
            {
                ClientId = createRequest.ClientId,
                Name = createRequest.Name,
                Birthday = createRequest.Birthday,
            });
            return Ok(res);
        }

        [HttpPut("update")]
        public ActionResult<int> Update([FromBody] UpdatePetRequest updateRequest)
        {
            int res = _petRepository.Update(new Pet
            {
                PetId = updateRequest.PetId,
                ClientId = updateRequest.ClientId,
                Name = updateRequest.Name,
                Birthday = updateRequest.Birthday,
            });
            return Ok(res);
        }


        [HttpDelete("delete")]
        public ActionResult<int> Delete(int petId)
        {
            int res = _petRepository.Delete(petId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        public ActionResult<List<Pet>> GetAll()
        {
            return Ok(_petRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        public ActionResult<Pet> GetById(int petId)
        {
            return Ok(_petRepository.GetById(petId));
        }

    }
}
