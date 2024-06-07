﻿using System.ComponentModel.DataAnnotations;

namespace newZealandWalks.API.Models.DTO
{
    public class RegionAddRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be a minimum of 3 characters")]
        [MaxLength(3, ErrorMessage = "Code has to be a maximum of 3 characters")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name can not be greater than 100 characters")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
