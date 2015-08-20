namespace CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp.XmlRPC
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class Array : Value, IEnumerable<Value>, IEnumerable
	{
		private readonly List<Value> items;
		public Value this[int index]
		{
			get
			{
				return this.items[index];
			}
		}
		public static string TypeString
		{
			get
			{
				return "array";
			}
		}
		public int Count
		{
			get
			{
				return this.items.Count;
			}
		}
		public Array()
		{
			this.items = new List<Value>();
		}
		public Array(int capacity)
		{
			this.items = new List<Value>(capacity);
		}
		public void Add(Value v)
		{
			this.items.Add(v);
		}
		public void Add(int v)
		{
			this.items.Add(new IntegerValue(v));
		}
		public void Add(double v)
		{
			this.items.Add(new DoubleValue(v));
		}
		public void Add(bool v)
		{
			this.items.Add(new BooleanValue(v));
		}
		public void Add(DateTime v)
		{
			this.items.Add(new DateTimeValue(v));
		}
		public void AddRange(IEnumerable<Value> items)
		{
			foreach (Value current in items)
			{
				this.items.Add(current);
			}
		}
		public IEnumerator<Value> GetEnumerator()
		{
			return this.items.GetEnumerator();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
		protected override void AddToTypeEl(XElement parent)
		{
			XElement xElement = new XElement("data");
			parent.Add(xElement);
			foreach (Value current in this)
			{
				current.AddXmlElement(xElement);
			}
		}
		internal static Array XmlToValue(XElement type_el)
		{
			XElement element = type_el.GetElement("data");
			List<XElement> list = element.Elements("value").ToList<XElement>();
			Array array = new Array();
			foreach (XElement current in list)
			{
				Value v = Value.ParseXml(current);
				array.Add(v);
			}
			return array;
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
				Array array = obj as Array;
				if (array == null)
				{
					result = false;
				}
				else
				{
					if (this.items != array.items)
					{
						if (this.items.Count != array.items.Count)
						{
							result = false;
						}
						else
						{
							for (int i = 0; i < this.items.Count; i++)
							{
								if (!this.items[i].Equals(array[i]))
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
			return Array.TypeString;
		}
		public override int GetHashCode()
		{
			return this.items.GetHashCode();
		}
	}
}
