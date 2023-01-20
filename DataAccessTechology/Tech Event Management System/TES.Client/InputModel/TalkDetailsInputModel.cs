using System.ComponentModel.DataAnnotations;

namespace TES.Client.InputModel
{
    public class TalkDetailsInputModel
    {
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
