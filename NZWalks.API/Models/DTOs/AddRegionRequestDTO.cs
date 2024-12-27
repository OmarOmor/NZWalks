namespace NZWalks.API.Models.DTOs
{
    public class AddRegionRequestDTO
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string? RegionImageURL { get; set; }
    }
}
