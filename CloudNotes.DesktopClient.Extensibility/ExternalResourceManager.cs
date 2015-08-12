namespace CloudNotes.DesktopClient.Extensibility
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Apworks;

    /// <summary>
    /// Represents the base class of the external resource manager.
    /// </summary>
    /// <typeparam name="TResource">The type of the resource.</typeparam>
    internal abstract class ExternalResourceManager<TResource>
        where TResource : class, IEntity
    {
        #region Private Fields
        private readonly string path;
        private readonly string searchPattern;
        private readonly Dictionary<Guid, TResource> resources = new Dictionary<Guid, TResource>();
        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalResourceManager{TResource}"/> class.
        /// </summary>
        /// <param name="path">The path from which the resource is searching.</param>
        /// <param name="searchPattern">The search pattern.</param>
        protected ExternalResourceManager(string path, string searchPattern)
        {
            this.path = path;
            this.searchPattern = searchPattern;
        }
        #endregion

        #region Public Events

        /// <summary>
        /// The event that occurs when the resource is loaded.
        /// </summary>
        public event EventHandler<ExternalResourceLoadEventArgs<TResource>> ResourceLoaded;
        #endregion

        #region Protected Methods

        /// <summary>
        /// The event handler method which will be invoked when the resource is loaded.
        /// </summary>
        /// <param name="resource">The resource.</param>
        protected virtual void OnResourceLoaded(TResource resource)
        {
            var handler = this.ResourceLoaded;
            if (handler != null)
            {
                handler(this, new ExternalResourceLoadEventArgs<TResource>(resource));
            }
        }

        /// <summary>
        /// Loads the resources from the given file.
        /// </summary>
        /// <param name="fileName">Name of the file from which the resource is loaded.</param>
        /// <returns>A list of resource instances.</returns>
        protected abstract IEnumerable<TResource> LoadResources(string fileName);

        #endregion

        #region Protected Properties

        /// <summary>
        /// Gets all the resources that have been loaded to the current manager.
        /// </summary>
        /// <value>
        /// The resources.
        /// </value>
        protected Dictionary<Guid, TResource> Resources { get { return resources; } }
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether this instance has resource.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has resource; otherwise, <c>false</c>.
        /// </value>
        public bool HasResource
        {
            get { return this.resources.Count > 0; }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Loads the resources into the current manager.
        /// </summary>
        public void Load()
        {
            if (Directory.Exists(this.path))
            {
                var resourceFiles = Directory.EnumerateFiles(this.path, this.searchPattern, SearchOption.AllDirectories);

                foreach (var resourceFile in resourceFiles)
                {
                    try
                    {
                        var res = LoadResources(resourceFile);
                        if (res != null && res.Any())
                        {
                            foreach (var resource in res)
                            {
                                this.resources.Add(resource.ID, resource);
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        /// <summary>
        /// Gets the resource by using its unique key identifier from the current manager.
        /// </summary>
        /// <param name="key">The unique key identifier of the resource.</param>
        /// <returns>The resource instance.</returns>
        public TResource GetByKey(Guid key)
        {
            return this.resources[key];
        }

        #endregion
    }
}
