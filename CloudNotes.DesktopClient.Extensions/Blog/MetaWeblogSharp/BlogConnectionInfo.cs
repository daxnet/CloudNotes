namespace CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp
{
	using System.Net;
	using System.Xml.Linq;

	public class BlogConnectionInfo
	{
		public CookieContainer Cookies = null;
		public string BlogURL
		{
			get;
			set;
		}
		public string MetaWeblogURL
		{
			get;
			set;
		}
		public string BlogID
		{
			get;
			set;
		}
		public string Username
		{
			get;
			set;
		}
		public string Password
		{
			get;
			set;
		}
		public static BlogConnectionInfo Load(string filename)
		{
			XDocument xDocument = XDocument.Load(filename);
			XElement root = xDocument.Root;
			string elementString = root.GetElementString("blogurl");
			string elementString2 = root.GetElementString("blogid");
			string elementString3 = root.GetElementString("metaweblog_url");
			string elementString4 = root.GetElementString("username");
			string elementString5 = root.GetElementString("password");
			return new BlogConnectionInfo(elementString, elementString3, elementString2, elementString4, elementString5);
		}
		public void Save(string filename)
		{
			XDocument xDocument = new XDocument();
			XElement xElement = new XElement("blogconnectioninfo");
			xDocument.Add(xElement);
			xElement.Add(new XElement("blogurl", this.BlogURL));
			xElement.Add(new XElement("blogid", this.BlogID));
			xElement.Add(new XElement("metaweblog_url", this.MetaWeblogURL));
			xElement.Add(new XElement("username", this.Username));
			xElement.Add(new XElement("password", this.Password));
			xDocument.Save(filename);
		}
		public BlogConnectionInfo(string blogurl, string metaweblogurl, string blogid, string username, string password)
		{
			this.BlogURL = blogurl;
			this.BlogID = blogid;
			this.MetaWeblogURL = metaweblogurl;
			this.Username = username;
			this.Password = password;
		}
		private BlogConnectionInfo() : this(null, null, null, null, null)
		{
		}
	}
}
