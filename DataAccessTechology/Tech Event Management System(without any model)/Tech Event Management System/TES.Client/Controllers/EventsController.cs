using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TES.Business.Absrtaction;
using TES.Business.Entity;
using TES.Client.ViewModel;
using TES.Data.Entity;

namespace TES.Client.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsRepository _events;

        public EventsController(IEventsRepository events)
        {
            _events = events;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventsViewModel>>> GetEvents()
        {
            try
            {
                IEnumerable<Events> eventsData = await _events.GetEvents();

                if (eventsData == null)
                {
                    return NotFound();
                }
                IEnumerable<EventsViewModel> eventViewModels = convertDbModelToViewModel(eventsData);
                return Ok(eventViewModels);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventsViewModel>> GetEventsById(int id)
        {
            try
            {
                var eventsDataById = await _events.GetEventsById(id);

                if (eventsDataById == null)
                {
                    return NotFound();
                }
                EventsViewModel eventViewModels = convertDbModelToViewModel(eventsDataById);
                return Ok(eventViewModels);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("{month}/{yearNumber}")]
        public async Task<ActionResult<IEnumerable<EventsViewModel>>> GetEventsByCurrentMonth(int month, int yearNumber)
        {
            try
            {
                IEnumerable<Events> eventsByCurrentMonth = await _events.GetEventsByCurrectMonth(month, yearNumber);

                if (eventsByCurrentMonth == null)
                {
                    return NotFound();
                }
                IEnumerable<EventsViewModel> eventViewModels = convertDbModelToViewModel(eventsByCurrentMonth);
                return Ok(eventViewModels);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("completed")]
        public async Task<ActionResult<IEnumerable<Events>>> GetEventsByCompleted()
        {
            try
            {
                IEnumerable<Events> eventsByCompleted = await _events.GetEventsByCompleted();

                if (eventsByCompleted == null)
                {
                    return NotFound();
                }
                IEnumerable<EventsViewModel> eventViewModels = convertDbModelToViewModel(eventsByCompleted);
                return Ok(eventViewModels);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<Events>> AddEvents(Events events)
        {
            try
            {
                if (events == null)
                {
                    return BadRequest();
                }
                await _events.AddEvents(events);
                return CreatedAtAction("GetEvents", new { id = events.Id }, events);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Events>> UpdateEvents(int id, Events events)
        {
            try
            {
                if (events == null || id != events.Id || id == 0)
                {
                    return BadRequest();
                }
                await _events.UpdateEvents(id, events);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Events>> DeleteEvents(int id)
        {
            try
            {
                var events = await _events.GetEventsById(id);
                if (events == null)
                {
                    return BadRequest();
                }
                await _events.DeleteEvents(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private static IEnumerable<EventsViewModel> convertDbModelToViewModel(IEnumerable<Events> events)
        {
            ICollection<EventsViewModel> eventViewModels = new List<EventsViewModel>();
            foreach (var data in events)
            {
                eventViewModels.Add(new EventsViewModel
                {
                    Id = data.Id,
                    Description = data.Description,
                    Name = data.Name,
                    StartDate = data.StartDate,
                    EndDate = data.EndDate,
                    IsCompleted = data.IsCompleted,
                    VenueId = data.VenueId,
                });
            }
            return eventViewModels;
        }

        private static EventsViewModel convertDbModelToViewModel(Events events)
        {
            EventsViewModel eventViewModels = new EventsViewModel();
            eventViewModels.Id = events.Id;
            eventViewModels.Description = events.Description;
            eventViewModels.Name = events.Name;
            eventViewModels.StartDate = events.StartDate;
            eventViewModels.EndDate = events.EndDate;
            eventViewModels.IsCompleted = events.IsCompleted;
            eventViewModels.VenueId = events.VenueId;
            return eventViewModels;
        }
    }
}

