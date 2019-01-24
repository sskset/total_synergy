using Microsoft.EntityFrameworkCore;

namespace ProjectContactAPI.Models
{
    public class ManagingContext : DbContext
    {
        public ManagingContext(DbContextOptions<ManagingContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectContact>().HasKey(x => new { x.ContactId, x.ProjectId });

            modelBuilder.Entity<ProjectContact>().HasOne(x => x.Project).WithMany(x => x.ProjectContacts).HasForeignKey(x => x.ProjectId);

            modelBuilder.Entity<ProjectContact>().HasOne(x => x.Contact).WithMany(x => x.ContactProjects).HasForeignKey(x => x.ContactId);
        }

        public DbSet<ProjectContact> ProjectContacts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
