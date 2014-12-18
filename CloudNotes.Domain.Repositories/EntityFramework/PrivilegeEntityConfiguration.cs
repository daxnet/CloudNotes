using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CloudNotes.Domain.Model;

namespace CloudNotes.Domain.Repositories.EntityFramework
{
    public class PrivilegeEntityConfiguration : EntityTypeConfiguration<Privilege>
    {
        public PrivilegeEntityConfiguration()
        {
            HasKey(x => x.ID);
            Property(x => x.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(16)
                .IsUnicode();
            Property(x => x.Description)
                .HasMaxLength(256)
                .IsUnicode();
        }
    }
}