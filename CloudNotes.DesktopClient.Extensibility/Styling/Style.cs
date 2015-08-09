namespace CloudNotes.DesktopClient.Extensibility.Styling
{
    using System;
    using Apworks;

    /// <summary>
    /// Represents the style of the letter paper.
    /// </summary>
    public class Style : IEntity
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }
        public string Content { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
