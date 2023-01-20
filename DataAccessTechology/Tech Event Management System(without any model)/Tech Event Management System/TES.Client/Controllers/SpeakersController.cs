using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TES.Business.Absrtaction;
using TES.Business.Entity;
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
                IEnumerable<SpeakersViewModel> speakerViewModels = convertDbModelToViewModel(speakersData);
                return Ok(speakerViewModels);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpeakersViewModel>> GetSpeakersById(int id)
        {
            try
            { 
                var speakersDataById = await _speaker.GetSpeakersById(id);

                if (speakersDataById == null)
                {
                    return NotFound();
                }
                SpeakersViewModel speakerViewModels = convertDbModelToViewModel(speakersDataById);
                return Ok(speakerViewModels);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Speakers>> AddSpeakers(Speakers speakers)
        {
            try 
            { 
                if(speakers == null)
                {
                    return BadRequest();
                }
                await _speaker.AddSpeakers(speakers);
                return CreatedAtAction("GetSpeakersById", new { id = speakers.Id }, speakers);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Speakers>> UpdateSpeakers(int id, Speakers speakers)
        {
            try 
            {     
                if(id == 0 || id != speakers.Id || speakers == null)
                {
                    return BadRequest();
                }
                await _speaker.UpdateSpeakers(id, speakers);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
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
                IEnumerable<SpeakersViewModel> speakerViewModels = convertDbModelToViewModel(speakersByEventID);
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
                IEnumerable<TalkDetailsViewModel> talkdetailViewModels = convertDbModelToViewModel(talksByEventIDSpeakerID);
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
                IEnumerable<SpeakersViewModel> speakerViewModels = convertDbModelToViewModel(speakerByEventIdAndSpeakerId);
                return Ok(speakerViewModels);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private static IEnumerable<SpeakersViewModel> convertDbModelToViewModel(IEnumerable<Speakers> speakers)
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
        private static SpeakersViewModel convertDbModelToViewModel(Speakers speakers)
        {
            SpeakersViewModel speakerViewModels = new SpeakersViewModel();
            speakerViewModels.Id = speakers.Id;
            speakerViewModels.Name = speakers.Name;
            speakerViewModels.Profile = speakers.Profile;
            speakerViewModels.Twitter = speakers.Twitter;
            return speakerViewModels;
        }

        private static IEnumerable<TalkDetailsViewModel> convertDbModelToViewModel(IEnumerable<TalkDetails> talks)
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
    }
}
