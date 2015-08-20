namespace CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp.XmlRPC
{
    using System.Globalization;
    using System.Xml.Linq;

    public class IntegerValue : Value
	{
		public readonly int Integer;
		public static string TypeString
		{
			get
			{
				return "int";
			}
		}
		public static string AlternateTypeString
		{
			get
			{
				return "i4";
			}
		}
		public IntegerValue(int i)
		{
			this.Integer = i;
		}
		protected override void AddToTypeEl(XElement parent)
		{
			parent.Value = this.Integer.ToString(CultureInfo.InvariantCulture);
		}
		public static IntegerValue XmlToValue(XElement parent)
		{
			return new IntegerValue(int.Parse(parent.Value));
		}
		public static implicit operator IntegerValue(int v)
		{
			return new IntegerValue(v);
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
				IntegerValue integerValue = obj as IntegerValue;
				result = (integerValue != null && this.Integer == integerValue.Integer);
			}
			return result;
		}
		public override int GetHashCode()
		{
			return this.Integer.GetHashCode();
		}
		protected override string GetTypeString()
		{
			return IntegerValue.TypeString;
		}
	}
}
