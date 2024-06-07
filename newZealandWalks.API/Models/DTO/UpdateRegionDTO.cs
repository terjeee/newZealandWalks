using System.ComponentModel.DataAnnotations;

namespace newZealandWalks.API.Models.DTO
{
    public class UpdateRegionDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "field 'code' is too short. Expected length = 3")]
        [MaxLength(3, ErrorMessage = "field 'code' is too long. Expected length = 3")]
        public string? Code { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "field 'name' is too long. Max length = 50")]
        public string? Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
