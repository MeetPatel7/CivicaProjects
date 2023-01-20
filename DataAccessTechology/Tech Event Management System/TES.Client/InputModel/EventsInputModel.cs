using System.ComponentModel.DataAnnotations;

namespace TES.Client.InputModel
{
    public class EventsInputModel
    {
        [Required]
        public int VenueId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
