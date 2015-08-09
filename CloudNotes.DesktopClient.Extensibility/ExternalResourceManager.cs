namespace CloudNotes.DesktopClient.Extensibility
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Apworks;

    internal abstract class ExternalResourceManager<TResource>
        where TResource : class, IEntity
    {
        #region Private Fields
        private readonly string path;
        private readonly string searchPattern;
        private readonly Dictionary<Guid, TResource> resources = new Dictionary<Guid, TResource>();
        #endregion

        protected ExternalResourceManager(string path, string searchPattern)
        {
            this.path = path;
            this.searchPattern = searchPattern;
        }

        public event EventHandler<ExternalResourceLoadEventArgs<TResource>> ResourceLoaded;

        protected virtual void OnResourceLoaded(TResource resource)
        {
            var handler = this.ResourceLoaded;
            if (handler != null)
            {
                handler(this, new ExternalResourceLoadEventArgs<TResource>(resource));
            }
        }

        protected Dictionary<Guid, TResource> Resources { get { return resources; } } 

        public bool HasResource
        {
            get { return this.resources.Count > 0; }
        }

        protected abstract IEnumerable<TResource> LoadResources(string fileName);

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

        public TResource GetByKey(Guid key)
        {
            return this.resources[key];
        }
    }
}
