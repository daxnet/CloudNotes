namespace CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp
{
    using System.Xml.Linq;

    internal static class XmlExtensions
	{
		public static string GetElementString(this XElement parent, string name)
		{
			XElement element = parent.GetElement(name);
			return element.Value;
		}
		public static XElement GetElement(this XElement parent, string name)
		{
			XElement xElement = parent.Element(name);
			if (xElement == null)
			{
				string message = string.Format("Xml Error: <{0}/> element does not contain <{0}/> element", parent.Name, name);
				throw new MetaWeblogException(message);
			}
			return xElement;
		}
	}
}
