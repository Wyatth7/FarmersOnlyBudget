using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.UserId);

        builder.Property(u => u.NameFull)
            .HasDefaultValue(string.Empty)
            .IsRequired();
        
        builder.Property(u => u.NameFirst)
            .HasDefaultValue(string.Empty)
            .HasMaxLength(250)
            .IsRequired();
        
        builder.Property(u => u.NameLast)
            .HasDefaultValue(string.Empty)
            .HasMaxLength(250)
            .IsRequired();
        
        builder.Property(u => u.Email)
            .HasDefaultValue(string.Empty)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(u => u.FirebaseId)
            .HasDefaultValue(string.Empty)
            .HasMaxLength(250)
            .IsRequired();
        
        builder.Property(u => u.Phone)
            .HasDefaultValue(string.Empty)
            .HasMaxLength(250)
            .IsRequired();
        
        builder.HasIndex(u => u.NameFull);
        builder.HasIndex(u => u.Email);
        builder.HasIndex(u => u.Phone);
        builder.HasIndex(u => u.FirebaseId);
    }
}