namespace CloudNotes.DesktopClient.Extensibility
{
    using System;
    using Apworks;

    /// <summary>
    /// Represents the object that carries the data of resource loaded event.
    /// </summary>
    /// <typeparam name="TResource">The type of the resource.</typeparam>
    internal sealed class ExternalResourceLoadEventArgs<TResource> : EventArgs
        where TResource : class, IEntity
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalResourceLoadEventArgs{TResource}"/> class.
        /// </summary>
        public ExternalResourceLoadEventArgs()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalResourceLoadEventArgs{TResource}"/> class.
        /// </summary>
        /// <param name="resource">The resource.</param>
        public ExternalResourceLoadEventArgs(TResource resource)
        {
            this.Resource = resource;
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the resource.
        /// </summary>
        /// <value>
        /// The resource.
        /// </value>
        public TResource Resource { get; set; }
        #endregion
    }
}
