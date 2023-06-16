namespace MeetingsWebApi.DTO.Response
{
    public class BaseResponseDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
