namespace CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp.XmlRPC
{
    using System;
    using System.Globalization;
    using System.Xml.Linq;

    public class DateTimeValue : Value
	{
		public readonly DateTime Data;
		public static string TypeString
		{
			get
			{
				return "dateTime.iso8601";
			}
		}
		public DateTimeValue(DateTime value)
		{
			this.Data = value;
		}
		protected override void AddToTypeEl(XElement parent)
		{
			string text = this.Data.ToString("s", CultureInfo.InvariantCulture);
			text = text.Replace("-", "");
			parent.Value = text;
		}
		public static DateTimeValue XmlToValue(XElement parent)
		{
			DateTime now = DateTime.Now;
			DateTimeValue result;
			if (DateTime.TryParse(parent.Value, out now))
			{
				result = new DateTimeValue(now);
			}
			else
			{
				string s = parent.Value.Trim(new char[]
				{
					'Z'
				});
				DateTime value = DateTime.ParseExact(s, "yyyyMMddTHH:mm:ss", null);
				DateTimeValue dateTimeValue = new DateTimeValue(value);
				result = dateTimeValue;
			}
			return result;
		}
		public static implicit operator DateTimeValue(DateTime v)
		{
			return new DateTimeValue(v);
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
				DateTimeValue dateTimeValue = obj as DateTimeValue;
				result = (dateTimeValue != null && (this.Data.Day == dateTimeValue.Data.Day && this.Data.Month == dateTimeValue.Data.Month && this.Data.Year == dateTimeValue.Data.Year) && (this.Data.Hour == dateTimeValue.Data.Hour && this.Data.Minute == dateTimeValue.Data.Minute) && this.Data.Second == dateTimeValue.Data.Second);
			}
			return result;
		}
		public override int GetHashCode()
		{
			return this.Data.GetHashCode();
		}
		protected override string GetTypeString()
		{
			return DateTimeValue.TypeString;
		}
	}
}
