using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TES.Business.Absrtaction;
using TES.Business.Entity;
using TES.Client.InputModel;
using TES.Client.UpdateModel;
using TES.Client.ViewModel;
using TES.Data.Repository;

namespace TES.Client.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SpeakersController : ControllerBase
    {
        private readonly ISpeakersRepository _speaker;

        public SpeakersController(ISpeakersRepository speaker)
        {
            _speaker = speaker;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpeakersViewModel>>> GetSpeakers()
        {
            try
            {
                IEnumerable<Speakers> speakersData = await _speaker.GetSpeakers();

                if(speakersData == null)
                {
                    return NotFound();
                }
                IEnumerable<SpeakersViewModel> speakerViewModels = ConvertDbModelToViewModel(speakersData);
                return Ok(speakerViewModels);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}", Name= "GetSpeakersById")]
        public async Task<ActionResult<SpeakersViewModel>> GetSpeakersById(int id)
        {
            try
            { 
                var speakersDataById = await _speaker.GetSpeakersById(id);

                if (speakersDataById == null)
                {
                    return NotFound();
                }
                SpeakersViewModel speakerViewModels = ConvertDbModelToViewModel(speakersDataById);
                return Ok(speakerViewModels);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSpeakers([FromForm] SpeakersInputModel speakersInputModel, [FromServices] IWebHostEnvironment environment)
        {
            try
            {
                if (speakersInputModel != null)
                {
                    await SavePostImageAsync(speakersInputModel.Pic, environment);

                    Speakers speakers = ConvertInputModelToDbModel(speakersInputModel);

                    await _speaker.AddSpeakers(speakers);

                    await GetSpeakersById(speakers.Id);

                    return CreatedAtRoute("GetSpeakersById", new { id = speakers.Id }, speakers);
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
        public async Task<IActionResult> UpdateSpeakers([FromForm] SpeakersUpdateModel speakersUpdateModel, [FromServices] IWebHostEnvironment environment, int id)
        {
            try
            {
                if (speakersUpdateModel != null)
                {
                    await SavePostImageAsync(speakersUpdateModel.Pic, environment);

                    Speakers speakers = ConvertUpdateModelToDbModel(speakersUpdateModel);

                    await _speaker.UpdateSpeakers(id, speakers);

                    await GetSpeakersById(speakers.Id);

                    return CreatedAtRoute("GetSpeakersById", new { id = speakers.Id }, speakers);
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
        public async Task<ActionResult<Speakers>> DeleteSpeakers(int id)
        {
            try
            { 
                var deleteSpeakers = await _speaker.GetSpeakersById(id);
                if(deleteSpeakers == null)
                {
                    return BadRequest();
                }
                _speaker.DeleteSpeakers(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("/api/v1/events/{id}/authors")]
        public async Task<ActionResult<IEnumerable<SpeakersViewModel>>> GetSpeakersByEventID(int id)
        {
            try
            {
                IEnumerable<Speakers> speakersByEventID = await _speaker.GetSpeakersByEventID(id);

                if (speakersByEventID == null)
                {
                    return NotFound();
                }
                IEnumerable<SpeakersViewModel> speakerViewModels = ConvertDbModelToViewModel(speakersByEventID);
                return Ok(speakerViewModels);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("/api/v1/events/{id}/authors/{sid}/talks")]
        public async Task<ActionResult<IEnumerable<TalkDetailsViewModel>>> GetTalksByEventIDSpeakerID(int id, int sid)
        {
            try
            {
                IEnumerable<TalkDetails> talksByEventIDSpeakerID = await _speaker.GetTalkDetailsByEventIDAndSpeakerID(id, sid);

                if (talksByEventIDSpeakerID == null)
                {
                    return NotFound();
                }
                IEnumerable<TalkDetailsViewModel> talkdetailViewModels = ConvertDbModelToViewModel(talksByEventIDSpeakerID);
                return Ok(talkdetailViewModels);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("/api/v1/events/{id}/authors/{sid}")]
        public async Task<ActionResult<IEnumerable<SpeakersViewModel>>> GetSpeakerByEventIdAndSpeakerId(int id, int sid)
        {
            try
            {
                IEnumerable<Speakers> speakerByEventIdAndSpeakerId = await _speaker.GetSpeakerByEventIdAndSpeakerId(id, sid);
                if (speakerByEventIdAndSpeakerId == null)
                {
                    return NotFound();
                }
                IEnumerable<SpeakersViewModel> speakerViewModels = ConvertDbModelToViewModel(speakerByEventIdAndSpeakerId);
                return Ok(speakerViewModels);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private static IEnumerable<SpeakersViewModel> ConvertDbModelToViewModel(IEnumerable<Speakers> speakers)
        {
            ICollection<SpeakersViewModel> speakerViewModels = new List<SpeakersViewModel>();
            foreach (var item in speakers)
            {
                speakerViewModels.Add(new SpeakersViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Profile = item.Profile,
                    Twitter = item.Twitter,
                    Pic = item.Pic,
                });
            }
            return speakerViewModels;
        }
        private static SpeakersViewModel ConvertDbModelToViewModel(Speakers speakers)
        {
            SpeakersViewModel speakerViewModels = new SpeakersViewModel();

            speakerViewModels.Id = speakers.Id;
            speakerViewModels.Name = speakers.Name;
            speakerViewModels.Profile = speakers.Profile;
            speakerViewModels.Twitter = speakers.Twitter;
            return speakerViewModels;
        }

        private static IEnumerable<TalkDetailsViewModel> ConvertDbModelToViewModel(IEnumerable<TalkDetails> talks)
        {
            ICollection<TalkDetailsViewModel> talkdetailViewModels = new List<TalkDetailsViewModel>();
            foreach (var data in talks)
            {
                talkdetailViewModels.Add(new TalkDetailsViewModel
                {
                    Id = data.Id,
                    Title = data.Title,
                    StartTime = data.StartTime,
                    EndTime = data.EndTime,
                    SpeakerId = data.SpeakerId,
                    EventId = data.EventId
                });
            }
            return talkdetailViewModels;
        }

        private static Speakers ConvertInputModelToDbModel(SpeakersInputModel speakersInputModel)
        {
            Speakers speakers = new()
            {
                Name = speakersInputModel.Name,
                Profile = speakersInputModel.Profile,
                LinkedInUrl = speakersInputModel.LinkedInUrl,
                Twitter = speakersInputModel.Twitter,
                Pic = speakersInputModel.Pic.FileName
            };
            return speakers;
        }

        private static async Task SavePostImageAsync(IFormFile newImage, IWebHostEnvironment environment)
        {
            if (newImage != null)
            {
                var uploadFileName = newImage.FileName;
                var rootPath = Path.Combine(environment.WebRootPath, "speakers");
                var filePath = Path.Combine(rootPath, uploadFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                await newImage.CopyToAsync(new FileStream(filePath, FileMode.Create));
            }
        }

        private static Speakers ConvertUpdateModelToDbModel(SpeakersUpdateModel speakersUpdateModel)
        {
            Speakers speakers = new()
            {
                Id = speakersUpdateModel.Id,
                Name = speakersUpdateModel.Name,
                Profile = speakersUpdateModel.Profile,
                LinkedInUrl = speakersUpdateModel.LinkedInUrl,
                Twitter = speakersUpdateModel.Twitter,
                Pic = speakersUpdateModel.Pic.FileName
            };
            return speakers;
        }
    }
}
