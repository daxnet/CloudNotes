using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CloudNotes.Domain.Model;

namespace CloudNotes.Domain.Repositories.EntityFramework
{
    public class RoleEntityConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleEntityConfiguration()
        {
            HasKey(x => x.ID);
            Property(x => x.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name)
                .HasMaxLength(16)
                .IsUnicode()
                .IsRequired();
            Property(x => x.Description)
                .HasMaxLength(256)
                .IsUnicode();
        }
    }
}