
using ItlaTv.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }


        #region Entities
        public DbSet<Serie> Series { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Studio> Studios { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region tables
            modelBuilder.Entity<Serie>().ToTable("Series");
            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<Studio>().ToTable("Studios");
            #endregion

            #region Primary Keys
            modelBuilder.Entity<Serie>().HasKey(se => se.ID);
            modelBuilder.Entity<Genre>().HasKey(g => g.ID);
            modelBuilder.Entity<Studio>().HasKey(st => st.ID);
            #endregion

            #region Relationships
            //One Studio Has Many Series
            modelBuilder.Entity<Studio>()
                .HasMany<Serie>()
                .WithOne(se => se.studio)
                .HasForeignKey(se => se.ID)
                .OnDelete(DeleteBehavior.Cascade);

            //Many Series Has Many Genres
            modelBuilder.Entity<Serie>()
                .HasMany(se => se.Genres)
                .WithMany(ge => ge.Series)
                .UsingEntity("SerieGenre");


            #endregion

            #region Property Configuration

            #region Serie
            modelBuilder.Entity<Serie>().Property(se => se.Name).HasMaxLength(80);
            #endregion
            #endregion
            base.OnModelCreating(modelBuilder);
        }


    }
}
