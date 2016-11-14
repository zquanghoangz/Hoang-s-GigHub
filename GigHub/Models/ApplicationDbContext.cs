using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GigHub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Gig)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Following>()
               .HasRequired(f => f.Followee)
               .WithMany()
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Following>()
              .HasRequired(f => f.Follower)
              .WithMany()
              .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);

            ////https://msdn.microsoft.com/en-us/data/jj591617.aspx?f=255&MSPPError=-2147217396d
            //modelBuilder.Entity<Gig>().HasKey(g => g.Id);
            //modelBuilder.Entity<Gig>().HasRequired(p => p.Artist);
            //modelBuilder.Entity<Gig>().HasRequired(p => p.Venue);
            //modelBuilder.Entity<Gig>().Property(g => g.Venue).HasMaxLength(225);
            //modelBuilder.Entity<Gig>().HasRequired(p => p.Genre);
        }
    }
}