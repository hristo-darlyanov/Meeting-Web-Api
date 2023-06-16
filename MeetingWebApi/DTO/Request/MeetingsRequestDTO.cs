using System.ComponentModel.DataAnnotations;

namespace MeetingsWebApi.DTO.Request
{
    public class MeetingsRequestDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [MaxLength (1000)]
        public string Participants { get; set; }
    }
}
