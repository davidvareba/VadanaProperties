using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VadanaProperties.Repositories;
using VadanaProperties.Models;

namespace VadanaProperties.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealtorsController : ControllerBase
    {
        private readonly IRealtorsRepository _realtorRepo;

        public RealtorsController(IRealtorsRepository realtorsRepository)
        {
            _realtorRepo = realtorsRepository;
        }

        // GET all realtors
        [HttpGet]
        public List<Realtor> GetAllRealtors()
        {
            return _realtorRepo.GetAllRealtors();
        }

        // GET realtor by their Id
        [HttpGet("Realtors/{id}")]
        public ActionResult GetRealtorById(int id)
        {
            Realtor realtor = _realtorRepo.GetRealtorById(id);
            if (realtor == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(realtor);
            }
        }

        // POST new realtor
        [HttpPost]
        public ActionResult CreateRealtor(Realtor newrealtor)
        {
            if (newrealtor == null)
            {
                return NotFound();
            }
            else
            {
                _realtorRepo.AddRealtor(newrealtor);
                return Ok(newrealtor);
            }
        }

        // PATCH a realtor
        [HttpPatch("Realtors/{id}")]
        public ActionResult EditRealtor(int id, Realtor updatedRealtor)
        {
            Realtor realtor = _realtorRepo.GetRealtorById(id);

            if (realtor != null)
            {
                _realtorRepo.UpdateRealtor(updatedRealtor);
                return Ok(updatedRealtor);

            }
            else
            {
                return BadRequest(realtor);
            }
        }

        // DELETE an realtor
        [HttpDelete("Realtors/{id}")]
        public ActionResult DeleteARealtor(int id, Realtor realtor)
        {
            try
            {
                _realtorRepo.DeleteRealtor(id);
                return Ok(realtor);
            }
            catch (Exception ex)
            {
                return BadRequest(realtor);
            }
        }
    }
}