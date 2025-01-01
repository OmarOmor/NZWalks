using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTOs
{
    public class AddRegionRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Min Length should be 3 characters")]
        [MaxLength(3, ErrorMessage = "Max Length should be 3 characters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }


        public string? RegionImageURL { get; set; }
    }
}
