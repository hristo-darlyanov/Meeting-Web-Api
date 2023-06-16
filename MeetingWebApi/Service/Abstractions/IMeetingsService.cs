using
    MeetingsWebApi.DTO.Request;
using MeetingsWebApi.DTO.Response;

namespace MeetingsWebApi.Service.Abstractions
{
    public interface IMeetingsService
    {
        Task<int> CreateMeetings(MeetingsRequestDTO Meetings);
        List<MeetingsResponseDTO> GetAll();
        MeetingsResponseDTO GetMeetings(int id);
        Task<MeetingsResponseDTO> UpdateMeetings(int id, MeetingsRequestDTO Meetings);
        Task<bool> DeleteMeetings(int id);
    }
}
