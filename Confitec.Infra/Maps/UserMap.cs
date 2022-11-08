using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Confitec.Domain.Entities;

namespace Confitec.Infra.Maps
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnType("int");

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(255)");

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("LastName")
                .HasColumnType("VARCHAR(255)");

            builder.OwnsOne(b => b.Email, b =>
            {
                b.Property(x => x.Address).IsRequired().HasColumnName("Email").HasColumnType("VARCHAR(255)");

                b.HasIndex(x => x.Address).HasDatabaseName("IxUserEmail").IsUnique(true);
            }).Navigation(b => b.Email);

            builder.Property(u => u.BirthDate)
                .IsRequired()
                .HasColumnName("BirthDate")
                .HasColumnType("date");

            builder.Property(u => u.Schooling)
                .IsRequired()
                .HasColumnName("Schooling")
                .HasColumnType("smallint");
        }
    }
}
