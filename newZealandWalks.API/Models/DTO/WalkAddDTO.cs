using System.ComponentModel.DataAnnotations;

namespace newZealandWalks.API.Models.DTO
{
    public class WalkAddDTO
    {
        [Required]
        [MaxLength(25, ErrorMessage = "Name too long")]
        public string Name { get; set; }
        [Required]
        [MinLength(25, ErrorMessage = "Description too short")]
        public string Description { get; set; }
        [Required]
        [Range(0, 50, ErrorMessage = "Range = 0-50")]
        public double LengthInKm { get; set; }
        [Required]
        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
