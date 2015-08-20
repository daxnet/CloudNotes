namespace CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp.XmlRPC
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class MethodResponse
	{
		public ParameterList Parameters
		{
			get;
			private set;
		}
		public MethodResponse(string content)
		{
			this.Parameters = new ParameterList();
			LoadOptions options = LoadOptions.None;
			XDocument xDocument = XDocument.Parse(content, options);
			XElement root = xDocument.Root;
			XElement xElement = root.Element("fault");
			if (xElement != null)
			{
				Fault fault = Fault.ParseXml(xElement);
				string message = string.Format("XMLRPC FAULT [{0}]: \"{1}\"", fault.FaultCode, fault.FaultString);
				throw new XmlRPCException(message)
				{
					Fault = fault
				};
			}
			XElement element = root.GetElement("params");
			List<XElement> list = element.Elements("param").ToList<XElement>();
			foreach (XElement current in list)
			{
				XElement element2 = current.GetElement("value");
				Value value = Value.ParseXml(element2);
				this.Parameters.Add(value);
			}
		}
	}
}
