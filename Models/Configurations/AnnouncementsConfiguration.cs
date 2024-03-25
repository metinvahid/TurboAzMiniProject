using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Turboazmini.Models.Entities;


namespace Turboazmini.Models.Configurations
{

  
    public class AnnouncementsConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int");
            builder.Property(m => m.ModelId).HasColumnType("int");
            builder.Property(m => m.March).HasColumnType("int");
            builder.Property(m => m.Price).HasColumnType("decimal").HasPrecision(18, 2);
            builder.Property(m => m.Banner).HasColumnType("int");
            builder.Property(m => m.FuelType).HasColumnType("int");
            builder.Property(m => m.GearBox).HasColumnType("int");
            builder.Property(m => m.Transmission).HasColumnType("int");
            builder.Property(m => m.CreatedBy).HasColumnType("int");
            builder.Property(m => m.CreatedAt).HasColumnType("datetime");
            builder.Property(m => m.LastModifiedBy).HasColumnType("int");
            builder.Property(m => m.LastModifiedAt).HasColumnType("datetime");
            builder.Property(m => m.DeletedBy).HasColumnType("int");
            builder.Property(m => m.DeletedAt).HasColumnType("datetime");


            builder.HasKey(m => m.Id);
            builder.ToTable("CarAnnouncement");

            builder.HasOne<Model>()
               .WithMany()
               .HasForeignKey(m => m.ModelId)
               .HasPrincipalKey(m => m.Id)
               .OnDelete(DeleteBehavior.NoAction);


        }
    }
}