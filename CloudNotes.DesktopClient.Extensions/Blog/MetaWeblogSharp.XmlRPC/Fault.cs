namespace CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp.XmlRPC
{
    using System.Xml.Linq;
    using CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp;

    public class Fault
	{
		public int FaultCode
		{
			get;
			set;
		}
		public string FaultString
		{
			get;
			set;
		}
		public string RawData
		{
			get;
			set;
		}
		public static Fault ParseXml(XElement fault_el)
		{
			XElement element = fault_el.GetElement("value");
			Struct @struct = (Struct)Value.ParseXml(element);
			int faultCode = -1;
			Value value = @struct.Get("faultCode");
			if (value != null)
			{
				if (value is StringValue)
				{
					StringValue stringValue = (StringValue)value;
					faultCode = int.Parse(stringValue.String);
				}
				else
				{
					if (!(value is IntegerValue))
					{
						string message = string.Format("Fault Code value is not int or string {0}", element.ToString());
						throw new MetaWeblogException(message);
					}
					IntegerValue integerValue = (IntegerValue)value;
					faultCode = integerValue.Integer;
				}
			}
			string @string = @struct.Get<StringValue>("faultString").String;
			return new Fault
			{
				FaultCode = faultCode,
				FaultString = @string,
				RawData = fault_el.Document.ToString()
			};
		}
	}
}
