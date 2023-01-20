using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TES.Business.Absrtaction;
using TES.Business.Entity;
using TES.Client.ViewModel;

namespace TES.Client.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly IVenueRepository _venue;

        public VenueController(IVenueRepository venue)
        {
            _venue = venue;
        }

        [HttpGet("[controller]")]
        public async Task<ActionResult<IEnumerable<VenueViewModel>>> GetVenue()
        {
            try
            {
                IEnumerable<Venue> venueData = await _venue.GetVenue();

                if (venueData == null)
                {
                    return NotFound();
                }
                IEnumerable<VenueViewModel> venueViewModel = convertDbModelToViewModel(venueData);
                return Ok(venueViewModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("[controller]/{id}")]
        public async Task<ActionResult<Venue>> GetVenueById(int id)
        {
            try
            {
                var venueDataById = await _venue.GetVenueById(id);

                if (venueDataById == null)
                {
                    return NotFound();
                }
                VenueViewModel venueViewModel = convertDbModelToViewModel(venueDataById);
                return Ok(venueViewModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("[controller]")]
        public async Task<ActionResult<Venue>> AddVenue(Venue venue)
        {
            try
            {
                if (venue == null)
                {
                    return BadRequest();
                }
                await _venue.AddVenue(venue);
                return CreatedAtAction("GetVenue", new { id = venue.Id }, venue);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("[controller]/{id}")]
        public async Task<ActionResult<Venue>> UpdateVenue(int id, Venue venue)
        {
            try
            {
                if (id == 0 || id != venue.Id || venue == null)
                {
                    return BadRequest();
                }
                await _venue.UpdateVenue(id, venue);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("[controller]/{id}")]
        public async Task<ActionResult<Venue>> DeleteVenue(int id)
        {
            try
            {
                var deleteVenue = await _venue.GetVenueById(id);
                if (deleteVenue == null)
                {
                    return BadRequest();
                }
                _venue.DeleteVenue(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("events/{id}/[controller]")]
        public async Task<ActionResult<IEnumerable<VenueViewModel>>> GetVenueByEventsId(int id)
        {
            try
            {
                IEnumerable<Venue> venueByEventsId = await _venue.GetVenueByEventsId(id);

                if (venueByEventsId == null)
                {
                    return NotFound();
                }
                IEnumerable<VenueViewModel> venueViewModel = convertDbModelToViewModel(venueByEventsId);
                return Ok(venueViewModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("events/{id}/[controller]/{vid}")]
        public async Task<ActionResult<IEnumerable<VenueViewModel>>> GetVenueByEventsIdAndVenueId(int id, int vid)
        {
            try
            {
                IEnumerable<Venue> venueByEventsIdAndVenueId = await _venue.GetVenueByEvenetsIdAndVenueId(id, vid);

                if (venueByEventsIdAndVenueId == null)
                {
                    return NotFound();
                }
                IEnumerable<VenueViewModel> venueViewModel = convertDbModelToViewModel(venueByEventsIdAndVenueId);
                return Ok(venueViewModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private static IEnumerable<VenueViewModel> convertDbModelToViewModel(IEnumerable<Venue> venue)
        {
            ICollection<VenueViewModel> venueViewModels = new List<VenueViewModel>();
            foreach (var data in venue)
            {
                venueViewModels.Add(new VenueViewModel
                {
                    Id = data.Id,
                    Name = data.Name,
                    Address = data.Address,
                    City = data.City,
                    State = data.State,
                    Pincode = data.Pincode,
                    MapUrl = data.MapUrl,
                    MobileNo = data.MobileNo,
                    Picture = data.Picture,
                });
            }
            return venueViewModels;
        }

        private static VenueViewModel convertDbModelToViewModel(Venue venue)
        {
            VenueViewModel venueViewModel = new VenueViewModel();
            venueViewModel.Id = venue.Id;
            venueViewModel.Name = venue.Name;
            venueViewModel.MobileNo = venue.MobileNo;
            venueViewModel.MapUrl = venue.MapUrl;
            venueViewModel.City = venue.City;
            venueViewModel.Address = venue.Address;
            venueViewModel.Pincode = venue.Pincode;
            venueViewModel.Picture = venue.Picture;
            venueViewModel.State = venue.State;

            return venueViewModel;
        }
    }

}
