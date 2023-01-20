using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TES.Business.Absrtaction;
using TES.Business.Entity;
using TES.Client.InputModel;
using TES.Client.UpdateModel;
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
                IEnumerable<VenueViewModel> venueViewModel = ConvertDbModelToViewModel(venueData);
                return Ok(venueViewModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("[controller]/{id}", Name = "GetVenueById")]
        public async Task<ActionResult<Venue>> GetVenueById(int id)
        {
            try
            {
                var venueDataById = await _venue.GetVenueById(id);

                if (venueDataById == null)
                {
                    return NotFound();
                }
                VenueViewModel venueViewModel = ConvertDbModelToViewModel(venueDataById);
                return Ok(venueViewModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("[controller]")]
        public async Task<IActionResult> AddVenue([FromForm] VenueInputModel venueInputModel, [FromServices] IWebHostEnvironment environment)
        {
            try
            {
                if (venueInputModel != null)
                {
                    await SavePostImageAsync(venueInputModel.Picture, environment);

                    Venue venue = ConvertInputModelToDbModel(venueInputModel);

                    await _venue.AddVenue(venue);

                    await GetVenueById(venue.Id);

                    return CreatedAtRoute("GetVenueById", new { id = venue.Id }, venue);
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

        [HttpPut("[controller]/{id}")]
        public async Task<IActionResult> UpdateVenue([FromForm] VenueUpdateModel venueUpdateModel, [FromServices] IWebHostEnvironment environment, int id)
        {
            try
            {
                if (venueUpdateModel != null)
                {
                    await SavePostImageAsync(venueUpdateModel.Picture, environment);

                    Venue venue = ConvertUpdateModelToDbModel(venueUpdateModel);

                    await _venue.UpdateVenue(id, venue);

                    await GetVenueById(venue.Id);

                    return CreatedAtRoute("GetEventsById", new { id = venue.Id }, venue);
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
                IEnumerable<VenueViewModel> venueViewModel = ConvertDbModelToViewModel(venueByEventsId);
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
                IEnumerable<VenueViewModel> venueViewModel = ConvertDbModelToViewModel(venueByEventsIdAndVenueId);
                return Ok(venueViewModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private static IEnumerable<VenueViewModel> ConvertDbModelToViewModel(IEnumerable<Venue> venue)
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

        private static VenueViewModel ConvertDbModelToViewModel(Venue venue)
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

        private static Venue ConvertInputModelToDbModel(VenueInputModel venueInputModel)
        {
            Venue venue = new()
            {
                Name = venueInputModel.Name,
                Address = venueInputModel.Address,
                City = venueInputModel.City,
                State = venueInputModel.State,
                Pincode = venueInputModel.Pincode,
                MapUrl = venueInputModel.MapUrl,
                MobileNo = venueInputModel.MobileNo,
                Picture = venueInputModel.Picture.FileName
            };
            return venue;
        }

        private static async Task SavePostImageAsync(IFormFile newImage, IWebHostEnvironment environment)
        {
            if (newImage != null)
            {
                var uploadFileName = newImage.FileName;
                var rootPath = Path.Combine(environment.WebRootPath, "venue");
                var filePath = Path.Combine(rootPath, uploadFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                await newImage.CopyToAsync(new FileStream(filePath, FileMode.Create));
            }
        }

        private static Venue ConvertUpdateModelToDbModel(VenueUpdateModel venueUpdateModel)
        {
            Venue venue = new()
            {
                Id = venueUpdateModel.Id,
                Name = venueUpdateModel.Name,
                Address = venueUpdateModel.Address,
                City = venueUpdateModel.City,
                State = venueUpdateModel.State,
                Pincode = venueUpdateModel.Pincode,
                MapUrl = venueUpdateModel.MapUrl,
                MobileNo = venueUpdateModel.MobileNo,
                Picture = venueUpdateModel.Picture.FileName
            };
            return venue;
        }
    }
}
