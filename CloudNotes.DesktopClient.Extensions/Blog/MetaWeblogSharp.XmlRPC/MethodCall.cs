namespace CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp.XmlRPC
{
    using System.Xml.Linq;

    public class MethodCall
	{
		public ParameterList Parameters
		{
			get;
			private set;
		}
		public string Name
		{
			get;
			private set;
		}
		public MethodCall(string name)
		{
			this.Name = name;
			this.Parameters = new ParameterList();
		}
		public XDocument CreateDocument()
		{
			XDocument xDocument = new XDocument();
			XElement xElement = new XElement("methodCall");
			xDocument.Add(xElement);
			XElement xElement2 = new XElement("methodName");
			xElement.Add(xElement2);
			xElement2.Add(this.Name);
			XElement xElement3 = new XElement("params");
			xElement.Add(xElement3);
			foreach (Value current in this.Parameters)
			{
				XElement xElement4 = new XElement("param");
				xElement3.Add(xElement4);
				current.AddXmlElement(xElement4);
			}
			return xDocument;
		}
	}
}
