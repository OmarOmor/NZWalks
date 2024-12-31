﻿namespace NZWalks.API.Models.DTOs
{
    public class WalksDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double LengthInKm { get; set; }

        public string? WalkImageURL { get; set; }


        public Guid DifficultyId { get; set; }

        public Guid RegionId { get; set; }
    }
}
