namespace CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp.XmlRPC
{
    using System;
    using System.Xml.Linq;

    public class Base64Data : Value
	{
		public byte[] Bytes
		{
			get;
			private set;
		}
		public static string TypeString
		{
			get
			{
				return "base64";
			}
		}
		public Base64Data(byte[] bytes)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			this.Bytes = bytes;
		}
		protected override void AddToTypeEl(XElement parent)
		{
			parent.Add(Convert.ToBase64String(this.Bytes));
		}
		internal static Base64Data XmlToValue(XElement type_el)
		{
			byte[] bytes = Convert.FromBase64String(type_el.Value);
			return new Base64Data(bytes);
		}
		public static implicit operator Base64Data(byte[] v)
		{
			return new Base64Data(v);
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
				Base64Data base64Data = obj as Base64Data;
				if (base64Data == null)
				{
					result = false;
				}
				else
				{
					if (this.Bytes != base64Data.Bytes)
					{
						if (this.Bytes.Length != base64Data.Bytes.Length)
						{
							result = false;
						}
						else
						{
							for (int i = 0; i < this.Bytes.Length; i++)
							{
								if (this.Bytes[i] != base64Data.Bytes[i])
								{
									result = false;
									return result;
								}
							}
							result = true;
						}
					}
					else
					{
						result = true;
					}
				}
			}
			return result;
		}
		protected override string GetTypeString()
		{
			return Base64Data.TypeString;
		}
		public override int GetHashCode()
		{
			return this.Bytes.GetHashCode();
		}
	}
}
