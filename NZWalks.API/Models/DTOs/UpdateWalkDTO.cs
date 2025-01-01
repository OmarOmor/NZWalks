using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTOs
{
    public class UpdateWalkDTO
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Max length can be only 100 characters")]
        public string Name { get; set; }


        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public double LengthInKm { get; set; }

        public string? WalkImageURL { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }

        [Required]
        public Guid RegionId { get; set; }
    }
}
