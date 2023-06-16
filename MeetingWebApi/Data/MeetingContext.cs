using Microsoft.EntityFrameworkCore;

namespace MeetingsWebApi.Data
{
    public class MeetingContext : DbContext
    {
        public MeetingContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Meeting> Meeting { get; set; }
    }
}
