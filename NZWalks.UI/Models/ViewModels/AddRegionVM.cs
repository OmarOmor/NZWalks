using System.ComponentModel.DataAnnotations;

namespace NZWalks.UI.Models.ViewModels
{
    public class AddRegionVM
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
