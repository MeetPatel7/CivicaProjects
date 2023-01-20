namespace TES.Client.ViewModel
{
    public class TalkDetailsViewModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int SpeakerId { get; set; }
        public string Title { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
