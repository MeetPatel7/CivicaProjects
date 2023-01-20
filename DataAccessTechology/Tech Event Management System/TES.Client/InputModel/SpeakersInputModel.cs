using System.ComponentModel.DataAnnotations;

namespace TES.Client.InputModel
{
    public class SpeakersInputModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Profile { get; set; }
        [Required]
        public string LinkedInUrl { get; set; }
        [Required]
        public string Twitter { get; set; }
        [Required]
        public IFormFile Pic { get; set; }
    }
}
