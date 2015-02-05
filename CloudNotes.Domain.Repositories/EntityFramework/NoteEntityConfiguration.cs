using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CloudNotes.Domain.Model;

namespace CloudNotes.Domain.Repositories.EntityFramework
{
    /// <summary>
    /// Represents the entity configuration for <see cref="Note"/> entity.
    /// </summary>
    public class NoteEntityConfiguration : EntityTypeConfiguration<Note>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoteEntityConfiguration"/> class.
        /// </summary>
        public NoteEntityConfiguration()
        {
            ToTable("Notes");
            HasKey(x => x.ID);
            Property(x => x.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Content)
                .IsMaxLength()
                .IsRequired()
                .IsUnicode();
            Property(x => x.DateLastModified)
                .IsOptional();
            Property(x => x.DatePublished)
                .IsRequired();
            Property(x => x.Title)
                .HasMaxLength(128)
                .IsRequired()
                .IsUnicode();
            Property(x => x.Weather);
            Property(x => x.Description)
                .IsMaxLength()
                .IsUnicode()
                .IsOptional();
            Property(x => x.ThumbnailBase64)
                .IsMaxLength()
                .IsUnicode()
                .IsOptional();
        }
    }
}