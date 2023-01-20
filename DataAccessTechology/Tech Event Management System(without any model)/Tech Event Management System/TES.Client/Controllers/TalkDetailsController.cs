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
    public class TalkDetailsController : ControllerBase
    {
        private readonly ITalkDetailsRepository _talkDetails;

        public TalkDetailsController(ITalkDetailsRepository talkDetails)
        {
            _talkDetails = talkDetails;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TalkDetailsViewModel>>> GetTalkDetails()
        {
            try
            {
                IEnumerable<TalkDetails> talkDetailsData = await _talkDetails.GetTalkDetails();

                if (talkDetailsData == null)
                {
                    return NotFound();
                }
                IEnumerable<TalkDetailsViewModel> talkdetailViewModel = convertDbModelToViewModel(talkDetailsData);
                return Ok(talkdetailViewModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TalkDetails>> GetTalkDetailsById(int id)
        {
            try
            {
                var talkDetailsDataById = await _talkDetails.GetTalkDetailsById(id);

                if (talkDetailsDataById == null)
                {
                    return NotFound();
                }
                TalkDetailsViewModel talkdetailViewModel = convertDbModelToViewModel(talkDetailsDataById);
                return Ok(talkdetailViewModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TalkDetails>> AddTalkDetails(TalkDetails talkDetails)
        {
            try
            {
                if (talkDetails == null)
                {
                    return BadRequest();
                }

                await _talkDetails.AddTalkDetails(talkDetails);
                return CreatedAtAction("GetTalkDetails", new { id = talkDetails.Id }, talkDetails);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TalkDetails>> UpdateTalkDetails(int id, TalkDetails talkDetails)
        {
            try
            {
                if (id == 0 || id != talkDetails.Id || talkDetails == null)
                {
                    return BadRequest();
                }
                await _talkDetails.UpdateTalkDetails(id, talkDetails);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TalkDetails>> DeleteTalkDetails(int id)
        {
            try
            {
                var deleteTalkDetails = await _talkDetails.GetTalkDetailsById(id);
                if (deleteTalkDetails == null)
                {
                    return BadRequest();
                }
                _talkDetails.DeleteTalkDetails(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private static IEnumerable<TalkDetailsViewModel> convertDbModelToViewModel(IEnumerable<TalkDetails> talks)
        {
            ICollection<TalkDetailsViewModel> talkdetailViewModel = new List<TalkDetailsViewModel>();
            foreach (var data in talks)
            {
                talkdetailViewModel.Add(new TalkDetailsViewModel
                {
                    Id = data.Id,
                    Title = data.Title,
                    StartTime = data.StartTime,
                    EndTime = data.EndTime,
                    SpeakerId = data.SpeakerId,
                    EventId = data.EventId
                });
            }
            return talkdetailViewModel;
        }

        private static TalkDetailsViewModel convertDbModelToViewModel(TalkDetails talkDetails)
        {
            TalkDetailsViewModel talkdetailViewModel = new TalkDetailsViewModel();
            talkdetailViewModel.Id = talkDetails.Id;
            talkdetailViewModel.Title = talkDetails.Title;
            talkdetailViewModel.StartTime = talkDetails.StartTime;
            talkdetailViewModel.EndTime = talkDetails.EndTime;
            talkdetailViewModel.SpeakerId = talkDetails.SpeakerId;
            talkdetailViewModel.EventId = talkDetails.EventId;

            return talkdetailViewModel;
        }
    }
}
