using Microsoft.EntityFrameworkCore;

namespace NoteProject.Models
{
    public class NoteDBContext : DbContext
    {
        public NoteDBContext(DbContextOptions<NoteDBContext> options)
            : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; } = null!;
    }
}
