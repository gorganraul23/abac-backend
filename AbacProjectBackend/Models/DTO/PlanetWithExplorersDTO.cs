﻿namespace AbacProjectBackend.Models.DTO
{
    public class PlanetWithExplorersDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public PlanetStatus Status { get; set; }

        public string ImagePath { get; set; }

        public string? Captain { get; set; }

        public List<string>? Robots { get; set; }

    }
}
