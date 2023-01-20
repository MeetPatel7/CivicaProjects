using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TES.Business.Absrtaction;
using TES.Business.Entity;
using TES.Client.InputModel;
using TES.Client.UpdateModel;
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
                IEnumerable<EventsViewModel> eventViewModels = ConvertDbModelToViewModel(eventsData);
                return Ok(eventViewModels);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("{id}", Name = "GetEventsById")]
        public async Task<ActionResult<EventsViewModel>> GetEventsById(int id)
        {
            try
            {
                var eventsDataById = await _events.GetEventsById(id);

                if (eventsDataById == null)
                {
                    return NotFound();
                }
                EventsViewModel eventViewModels = ConvertDbModelToViewModel(eventsDataById);
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
                IEnumerable<EventsViewModel> eventViewModels = ConvertDbModelToViewModel(eventsByCurrentMonth);
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
                IEnumerable<EventsViewModel> eventViewModels = ConvertDbModelToViewModel(eventsByCompleted);
                return Ok(eventViewModels);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEvents([FromForm] EventsInputModel eventsInputModel)
        {
            try
            {
                if (eventsInputModel != null)
                {
                    Events events = ConvertInputModeltoDbModel(eventsInputModel);

                    await _events.AddEvents(events);

                    await GetEventsById(events.Id);

                    return CreatedAtRoute("GetEventsById", new { id = events.Id }, events);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvents([FromForm] EventsUpdateModel eventsUpdateModel, int id)
        {
            try
            {
                if (eventsUpdateModel != null)
                {
                    Events events = ConvertUpdateModelToDbModel(eventsUpdateModel);

                    await _events.UpdateEvents(id, events);

                    await GetEventsById(events.Id);

                    return CreatedAtRoute("GetEventsById", new { id = events.Id }, events);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
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

        private static IEnumerable<EventsViewModel> ConvertDbModelToViewModel(IEnumerable<Events> events)
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

        private static EventsViewModel ConvertDbModelToViewModel(Events events)
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

        private static Events ConvertInputModeltoDbModel(EventsInputModel inputModel)
        {
            Events events = new()
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
                StartDate = inputModel.StartDate,
                EndDate = inputModel.EndDate,
                IsCompleted = inputModel.IsCompleted,
                VenueId = inputModel.VenueId
            };
            return events;
        }

        private static Events ConvertUpdateModelToDbModel(EventsUpdateModel eventsUpdateModel)
        {
            Events events = new()
            {
                Id = eventsUpdateModel.Id,
                Name = eventsUpdateModel.Name,
                Description = eventsUpdateModel.Description,
                StartDate = eventsUpdateModel.StartDate,
                EndDate = eventsUpdateModel.EndDate,
                IsCompleted = eventsUpdateModel.IsCompleted,
                VenueId = eventsUpdateModel.VenueId
            };
            return events;
        }
    }
}

