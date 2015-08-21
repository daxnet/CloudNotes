namespace CloudNotes.DesktopClient.Extensions.Blog
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp;

    /// <summary>
    /// Represents the web log access gateway.
    /// </summary>
    public sealed class BlogGateway
    {
        #region Private Fields
        private readonly Client blogClient;
        #endregion


        public BlogGateway(string metaWeblogAddress, string userName, string password)
        {
            this.blogClient =
                new Client(new BlogConnectionInfo(string.Empty, metaWeblogAddress, string.Empty, userName, password));
        }

        public async Task<bool> TestConnectionAsync()
        {
            var blog = (await this.blogClient.GetUsersBlogsAsync()).FirstOrDefault();
            return blog != null;
        }

        public async Task<List<CategoryInfo>> GetCategoriesAsync()
        {
            return await this.blogClient.GetCategoriesAsync();
        }

        public async Task<string> PublishBlog(PostInfo postInfo, IList<string> categories)
        {
            return await this.blogClient.NewPostAsync(postInfo, categories, true);
        }
    }
}
