namespace MeetingsWebApi.DTO.Response
{
    public class MeetingsResponseDTO : BaseResponseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Participants { get; set; }
    }
}
