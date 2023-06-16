using MeetingsWebApi.Data;
using MeetingsWebApi.DTO.Request;
using MeetingsWebApi.DTO.Response;
using MeetingsWebApi.Repository;
using MeetingsWebApi.Service.Abstractions;

namespace MeetingsWebApi.Service
{
    public class MeetingsService : IMeetingsService
    {
        private readonly IRepository<Meeting> _repository;
        public MeetingsService(IRepository<Meeting> repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateMeetings(MeetingsRequestDTO Meetings)
        {
            var item = await _repository.CreateOrUpdate(new Meeting()
            {
                Name = Meetings.Name,
                Description = Meetings.Description,
                Participants = Meetings.Participants,
            });
            return item.Id;
        }

        public async Task<bool> DeleteMeetings(int id)
        {
            return await _repository.RemoveById(id);
        }

        public List<MeetingsResponseDTO> GetAll()
        {
            return _repository.GetAll()
                .Select(item => new MeetingsResponseDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Participants = item.Participants,
                    Description = item.Description,
                    CreatedAt = item.CreatedAt,
                    ModifiedAt = item.ModifiedAt
                })
                .ToList();
        }

        public MeetingsResponseDTO GetMeetings(int id)
        {
            var item = _repository.GetById(id);
            return new MeetingsResponseDTO()
            {
                Id = item.Id,
                Name = item.Name,
                Participants = item.Participants,
                Description = item.Description,
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt
            };
        }

        public async Task<MeetingsResponseDTO> UpdateMeetings(int id, MeetingsRequestDTO Meetings)
        {
            var item = _repository.GetById(id);

            if (item != null)
            {
                item.Id = id;
                item.Name = Meetings.Name;
                item.Description = Meetings.Description;
                item.Participants = Meetings.Participants;

                var updatedItem = await _repository.CreateOrUpdate(item);
                return new MeetingsResponseDTO()
                {
                    Id = updatedItem.Id,
                    Name = updatedItem.Name,
                    Participants = item.Participants,
                    Description = updatedItem.Description,
                    CreatedAt = updatedItem.CreatedAt,
                    ModifiedAt = updatedItem.ModifiedAt
                };
            }
            else
            {
                return null;
            }
        }
    }
}
