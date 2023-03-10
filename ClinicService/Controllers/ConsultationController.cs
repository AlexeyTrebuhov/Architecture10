using ClinicService.Models.Requests;
using ClinicService.Models;
using ClinicService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Api.V2.Controllers
{
    [ApiController]
    //[ApiVersion("2.0")]
    [Route("api/[controller]")]
    public class ConsultationController : ControllerBase
    {
        private IConsultationRepository _consultationRepository;

        public ConsultationController(IConsultationRepository consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }

        [HttpPost("create")]
        public ActionResult<int> Create([FromBody] CreateConsultationRequest createRequest)
        {
            int res = _consultationRepository.Create(new Consultation
            {
                ClientId = createRequest.ClientId,
                PetId = createRequest.PetId,
                ConsultationDate = createRequest.ConsultationDate,
                Description = createRequest.Description,
            });
            return Ok(res);
        }

        [HttpPut("update")]
        public ActionResult<int> Update([FromBody] UpdateConsultationRequest updateRequest)
        {
            int res = _consultationRepository.Update(new Consultation
            {
                ConsultationId = updateRequest.ConsultationId,
                ClientId = updateRequest.ClientId,
                PetId = updateRequest.PetId,
                ConsultationDate = updateRequest.ConsultationDate,
                Description = updateRequest.Description,
            });
            return Ok(res);
        }


        [HttpDelete("delete")]
        public ActionResult<int> Delete(int consultationId)
        {
            int res = _consultationRepository.Delete(consultationId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        public ActionResult<List<Consultation>> GetAll()
        {
            return Ok(_consultationRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        public ActionResult<Consultation> GetById(int consultationId)
        {
            return Ok(_consultationRepository.GetById(consultationId));
        }

    }
}
