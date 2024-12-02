using Microsoft.EntityFrameworkCore;

namespace GamblerAPI.Model
{
    public partial class GamblerDbContext : DbContext
    {
        // Define constructror to take options passed when instatiated by application
        //        and pass those options to base (DbContext) cclass
        public GamblerDbContext(DbContextOptions<GamblerDbContext> options)
            : base(options) { }

        // Define property to represent the collection of data in the data source
        public virtual DbSet<Gambler> Gamblers { get; set; }

        // Define table and columns to be accessed using Entity Framework
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gambler>(entity =>
            {
                entity.ToTable("gambler");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired()
                    .HasColumnType("smallint");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("gambler_name")
                    .HasColumnType("text");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("text")
                    .HasDefaultValue("unknown");

                entity.Property(e => e.BirthDate)
                      .IsRequired()
                      .HasColumnName("birth_date")
                      .HasColumnType("date");

                entity.Property(e => e.Salary)
                    .IsRequired()
                    .HasColumnName("monthly_salary")
                    .HasColumnType("decimal(9,2)");

                OnModelCreatingPartial(modelBuilder);
            });  // End of modelBuilder.entity()
        }  // End of onModelCreating()

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        
    } // End of class
} // End of namespace
