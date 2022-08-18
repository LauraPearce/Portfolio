using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NailsByNikki.Models;
using NailsByNikki.Repositories;

namespace NailsByNikki.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AvailableSlotController : ControllerBase
    {
        IAvailableSlotRepository _availableSlotRepository;
        public AvailableSlotController(IAvailableSlotRepository repository)
        {
            _availableSlotRepository = repository;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<AvailableSlot>> GetAll()
        {
            return Ok(_availableSlotRepository.GetAll());
        }

        [HttpGet("GetById")]
        public ActionResult<AvailableSlot> GetById(int id)
        {
            AvailableSlot availableSlot = _availableSlotRepository.GetById(id);
            
            if (availableSlot is not null)
            {
                return Ok(availableSlot);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Create")]
        public IActionResult Create(DateTime startDateTime, DateTime endDateTime)
        {
            AvailableSlot newAvailableSlot = new AvailableSlot
            {
                StartDateTime = startDateTime,
                EndDateTime = endDateTime
            };

            if (newAvailableSlot.StartDateTime != DateTime.MinValue && newAvailableSlot.EndDateTime != DateTime.MinValue)
            {
                _availableSlotRepository.Create(newAvailableSlot);
                return CreatedAtAction(nameof(Create), new { id = newAvailableSlot.AvailableSlotId }, newAvailableSlot);
            }
            else
            {
                return BadRequest();            
            }
            
        }

        [HttpPatch("Update")]
        public ActionResult<AvailableSlot> Update(int id, DateTime startDateTime, DateTime endDateTime)
        {
            AvailableSlot updatedAvailableSlot = new AvailableSlot
            {
                AvailableSlotId = id,
                StartDateTime = startDateTime,
                EndDateTime = endDateTime
            };

            if (id >= 0
                && updatedAvailableSlot.StartDateTime != DateTime.MinValue 
                && updatedAvailableSlot.EndDateTime != DateTime.MinValue)
            {
                _availableSlotRepository.Update(updatedAvailableSlot);
                return Ok(updatedAvailableSlot);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("Delete")]
        public ActionResult<AvailableSlot> Delete(int id)
        {
            AvailableSlot availableSlotToDelete = _availableSlotRepository.GetById(id);

            if (availableSlotToDelete is not null)
            {   
                _availableSlotRepository.Delete(availableSlotToDelete);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetAllFreeSlotsBetweenTwoDates")]
        public ActionResult<IEnumerable<AvailableSlot>> GetAllFreeSlotsBetweenTwoDates(DateTime startDate, DateTime endDate)
        {
            IEnumerable<AvailableSlot> availableSlots = _availableSlotRepository.GetAllFreeSlotsBetweenTwoDates(startDate, endDate);
            
            if (availableSlots is not null)
            {
                return Ok(availableSlots);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("DeleteOldAvailabilitySlots")]
        public IActionResult DeleteOldAvailabilitySlots()
        {
            IEnumerable<AvailableSlot> oldAvailableSlotsToDelete = _availableSlotRepository.GetAll().Where(d => d.StartDateTime < DateTime.Now);

            if (oldAvailableSlotsToDelete is not null)
            {
                _availableSlotRepository.DeleteOldAvailabilitySlots(oldAvailableSlotsToDelete);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


    }
}
