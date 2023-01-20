using System.ComponentModel.DataAnnotations;

namespace TES.Client.UpdateModel
{
    public class TalkDetailsUpdateModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public int SpeakerId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Room { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Tags { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
    }
}
