using Microsoft.EntityFrameworkCore;

namespace CodingAssessment.Models
{
    public class OutputMessageContext : DbContext
    {
        public OutputMessageContext(DbContextOptions<OutputMessageContext> options) : base(options)
        {

        }

        public DbSet<OutputMessageItem> OutputMessageItems { get; set; }
    }
}
