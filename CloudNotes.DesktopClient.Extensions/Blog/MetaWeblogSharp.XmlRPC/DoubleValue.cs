namespace CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp.XmlRPC
{
    using System.Globalization;
    using System.Xml.Linq;

    public class DoubleValue : Value
	{
		public readonly double Double;
		public static string TypeString
		{
			get
			{
				return "double";
			}
		}
		public DoubleValue(double d)
		{
			this.Double = d;
		}
		protected override void AddToTypeEl(XElement parent)
		{
			parent.Value = this.Double.ToString(CultureInfo.InvariantCulture);
		}
		public static DoubleValue XmlToValue(XElement parent)
		{
			return new DoubleValue(double.Parse(parent.Value));
		}
		public static implicit operator DoubleValue(double v)
		{
			return new DoubleValue(v);
		}
		public override bool Equals(object obj)
		{
			bool result;
			if (obj == null)
			{
				result = false;
			}
			else
			{
				DoubleValue doubleValue = obj as DoubleValue;
				result = (doubleValue != null && this.Double == doubleValue.Double);
			}
			return result;
		}
		public override int GetHashCode()
		{
			return this.Double.GetHashCode();
		}
		protected override string GetTypeString()
		{
			return DoubleValue.TypeString;
		}
	}
}
