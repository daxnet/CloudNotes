namespace CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp.XmlRPC
{
    using System.Xml.Linq;

    public class StringValue : Value
	{
		public string String;
		private static StringValue ns;
		private static StringValue es;
		public static string TypeString
		{
			get
			{
				return "string";
			}
		}
		public static StringValue NullString
		{
			get
			{
				if (StringValue.ns == null)
				{
					StringValue.ns = new StringValue(null);
				}
				return StringValue.ns;
			}
		}
		public static StringValue EmptyString
		{
			get
			{
				if (StringValue.es == null)
				{
					StringValue.es = new StringValue(string.Empty);
				}
				return StringValue.es;
			}
		}
		public StringValue(string s)
		{
			this.String = s;
		}
		protected override void AddToTypeEl(XElement parent)
		{
			parent.Value = this.String;
		}
		public static StringValue XmlToValue(XElement parent)
		{
			return new StringValue(parent.Value);
		}
		public static implicit operator StringValue(string v)
		{
			return new StringValue(v);
		}
		protected override string GetTypeString()
		{
			return StringValue.TypeString;
		}
	}
}
