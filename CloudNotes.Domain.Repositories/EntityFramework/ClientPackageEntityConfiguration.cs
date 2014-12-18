using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CloudNotes.Domain.Model;

namespace CloudNotes.Domain.Repositories.EntityFramework
{
    public class ClientPackageEntityConfiguration : EntityTypeConfiguration<ClientPackage>
    {
        public ClientPackageEntityConfiguration()
        {
            ToTable("ClientPackages");
            HasKey(x => x.ID);
            Property(x => x.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ClientType).IsUnicode().IsRequired().HasMaxLength(64);
            Property(x => x.DatePublished).IsRequired();
            Property(x => x.Description).IsUnicode().IsRequired().HasMaxLength(256);
            Property(x => x.PackageFileName).IsUnicode().IsRequired().HasMaxLength(128);
            Property(x => x.PublishedBy).IsUnicode().IsRequired().HasMaxLength(64);
            Property(x => x.ReleaseNotes).IsUnicode().IsRequired().IsMaxLength();
            Property(x => x.Version).IsUnicode().IsRequired().HasMaxLength(128);
        }
    }
}
