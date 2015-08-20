namespace CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp.XmlRPC
{
    using System.Linq;
    using System.Xml.Linq;

    public abstract class Value
	{
		protected abstract void AddToTypeEl(XElement parent);
		protected abstract string GetTypeString();
		public static Value ParseXml(XElement value_el)
		{
			if (value_el.Name != "value")
			{
				string message = string.Format("XML Element should have name \"value\" instead found \"{0}\"", value_el.Name);
				throw new XmlRPCException();
			}
			string value = value_el.Value;
			Value result;
			if (value_el.HasElements)
			{
				XElement xElement = value_el.Elements().First<XElement>();
				string text = xElement.Name.ToString();
				if (text == Array.TypeString)
				{
					result = Array.XmlToValue(xElement);
				}
				else
				{
					if (text == Struct.TypeString)
					{
						result = Struct.XmlToValue(xElement);
					}
					else
					{
						if (text == StringValue.TypeString)
						{
							result = StringValue.XmlToValue(xElement);
						}
						else
						{
							if (text == DoubleValue.TypeString)
							{
								result = DoubleValue.XmlToValue(xElement);
							}
							else
							{
								if (text == Base64Data.TypeString)
								{
									result = Base64Data.XmlToValue(xElement);
								}
								else
								{
									if (text == DateTimeValue.TypeString)
									{
										result = DateTimeValue.XmlToValue(xElement);
									}
									else
									{
										if (text == IntegerValue.TypeString || text == IntegerValue.AlternateTypeString)
										{
											result = IntegerValue.XmlToValue(xElement);
										}
										else
										{
											if (!(text == BooleanValue.TypeString))
											{
												string message = string.Format("Unsupported type: {0}", text);
												throw new XmlRPCException(message);
											}
											result = BooleanValue.XmlToValue(xElement);
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				result = new StringValue(value);
			}
			return result;
		}
		public XElement AddXmlElement(XElement parent)
		{
			XElement xElement = new XElement("value");
			XElement xElement2 = new XElement(this.GetTypeString());
			xElement.Add(xElement2);
			this.AddToTypeEl(xElement2);
			parent.Add(xElement);
			return xElement;
		}
	}
}
