using System.ComponentModel.DataAnnotations;

namespace TES.Client.UpdateModel
{
    public class VenueUpdateModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int Pincode { get; set; }
        [Required]
        public string MapUrl { get; set; }
        [Required]
        public long MobileNo { get; set; }
        [Required]
        public IFormFile Picture { get; set; }
    }
}
