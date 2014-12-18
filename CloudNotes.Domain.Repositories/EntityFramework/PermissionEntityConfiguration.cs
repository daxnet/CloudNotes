using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CloudNotes.Domain.Model;

namespace CloudNotes.Domain.Repositories.EntityFramework
{
    public class PermissionEntityConfiguration : EntityTypeConfiguration<Permission>
    {
        public PermissionEntityConfiguration()
        {
            HasKey(x => x.ID);
            Property(x => x.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}