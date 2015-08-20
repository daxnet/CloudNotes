namespace CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp.XmlRPC
{
    using System.Xml.Linq;

    public class BooleanValue : Value
	{
		public readonly bool Boolean;
		public static string TypeString
		{
			get
			{
				return "boolean";
			}
		}
		public BooleanValue(bool value)
		{
			this.Boolean = value;
		}
		protected override void AddToTypeEl(XElement parent)
		{
			if (this.Boolean)
			{
				parent.Add("1");
			}
			else
			{
				parent.Add("0");
			}
		}
		public static BooleanValue XmlToValue(XElement type_el)
		{
			int num = int.Parse(type_el.Value);
			bool value = num != 0;
			return new BooleanValue(value);
		}
		public static implicit operator BooleanValue(bool v)
		{
			return new BooleanValue(v);
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
				BooleanValue booleanValue = obj as BooleanValue;
				result = (booleanValue != null && this.Boolean == booleanValue.Boolean);
			}
			return result;
		}
		public override int GetHashCode()
		{
			return this.Boolean.GetHashCode();
		}
		protected override string GetTypeString()
		{
			return BooleanValue.TypeString;
		}
	}
}
