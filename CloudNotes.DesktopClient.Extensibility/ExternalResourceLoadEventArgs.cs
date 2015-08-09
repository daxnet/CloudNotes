namespace CloudNotes.DesktopClient.Extensibility
{
    using System;
    using Apworks;

    internal sealed class ExternalResourceLoadEventArgs<TResource> : EventArgs
        where TResource : class, IEntity
    {
        public ExternalResourceLoadEventArgs()
        {
        }

        public ExternalResourceLoadEventArgs(TResource resource)
        {
            this.Resource = resource;
        }

        public TResource Resource { get; set; }
    }
}
