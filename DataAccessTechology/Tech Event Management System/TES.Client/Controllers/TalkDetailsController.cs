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
                IEnumerable<TalkDetailsViewModel> talkdetailViewModel = ConvertDbModelToViewModel(talkDetailsData);
                return Ok(talkdetailViewModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}", Name = "GetTalkDetailsById")]
        public async Task<ActionResult<TalkDetails>> GetTalkDetailsById(int id)
        {
            try
            {
                var talkDetailsDataById = await _talkDetails.GetTalkDetailsById(id);

                if (talkDetailsDataById == null)
                {
                    return NotFound();
                }
                TalkDetailsViewModel talkdetailViewModel = ConvertDbModelToViewModel(talkDetailsDataById);
                return Ok(talkdetailViewModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTalkDetails([FromForm] TalkDetailsInputModel talkDetailsInputModel)
        {
            try
            {
                if (talkDetailsInputModel != null)
                {

                    TalkDetails talkDetails = ConvertInputModelToDbModel(talkDetailsInputModel);

                    await _talkDetails.AddTalkDetails(talkDetails);

                    await GetTalkDetailsById(talkDetails.Id);

                    return CreatedAtRoute("GetTalkDetailsById", new { id = talkDetails.Id }, talkDetails);
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
        public async Task<IActionResult> UpdateTalkDetails([FromForm] TalkDetailsUpdateModel talkDetailsUpdateModel, int id)
        {
            try
            {
                if (talkDetailsUpdateModel != null)
                {
                    TalkDetails talkDetails = ConvertUpdateModelToDbModel(talkDetailsUpdateModel);

                    await _talkDetails.UpdateTalkDetails(id, talkDetails);

                    await GetTalkDetailsById(talkDetails.Id);

                    return CreatedAtRoute("GetTalkDetailsById", new { id = talkDetails.Id }, talkDetails);
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

        private static IEnumerable<TalkDetailsViewModel> ConvertDbModelToViewModel(IEnumerable<TalkDetails> talks)
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

        private static TalkDetailsViewModel ConvertDbModelToViewModel(TalkDetails talkDetails)
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

        private static TalkDetails ConvertInputModelToDbModel(TalkDetailsInputModel talkDetailsInputModel)
        {
            TalkDetails talkDetails = new()
            {
                EventId = talkDetailsInputModel.EventId,
                SpeakerId = talkDetailsInputModel.SpeakerId,
                Title = talkDetailsInputModel.Title,
                Room = talkDetailsInputModel.Room,
                Description = talkDetailsInputModel.Description,
                Tags = talkDetailsInputModel.Tags,
                StartTime = talkDetailsInputModel.StartTime,
                EndTime = talkDetailsInputModel.EndTime
            };
            return talkDetails;
        }

        private static TalkDetails ConvertUpdateModelToDbModel(TalkDetailsUpdateModel talkDetailsUpdateModel)
        {
            TalkDetails talkDetails = new()
            {
                Id = talkDetailsUpdateModel.Id,
                EventId = talkDetailsUpdateModel.EventId,
                SpeakerId = talkDetailsUpdateModel.SpeakerId,
                Title = talkDetailsUpdateModel.Title,
                Room = talkDetailsUpdateModel.Room,
                Description = talkDetailsUpdateModel.Description,
                Tags = talkDetailsUpdateModel.Tags,
                StartTime = talkDetailsUpdateModel.StartTime,
                EndTime = talkDetailsUpdateModel.EndTime
            };
            return talkDetails;
        }
    }
}
