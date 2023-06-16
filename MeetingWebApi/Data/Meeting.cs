namespace MeetingsWebApi.Data
{
    public class Meeting : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Participants { get; set; }
    }
}