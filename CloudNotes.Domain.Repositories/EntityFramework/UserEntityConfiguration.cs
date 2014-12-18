using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CloudNotes.Domain.Model;

namespace CloudNotes.Domain.Repositories.EntityFramework
{
    public class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            ToTable("Users");
            HasKey(x => x.ID);
            Property(x => x.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.DateRegistered)
                .IsRequired();
            Property(x => x.DateLastAuthenticated).IsOptional();
            Property(x => x.Password)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(256);
            Property(x => x.UserName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(16);
            Property(x => x.Email)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(128);
        }
    }
}