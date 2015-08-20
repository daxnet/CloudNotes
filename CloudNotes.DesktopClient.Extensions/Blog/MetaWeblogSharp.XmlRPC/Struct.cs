namespace CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp.XmlRPC
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class Struct : Value, IEnumerable<KeyValuePair<string, Value>>, IEnumerable
	{
		private readonly Dictionary<string, Value> dic;
		public Value this[string index]
		{
			get
			{
				return this.Get(index);
			}
			set
			{
				this.dic[index] = value;
			}
		}
		public int Count
		{
			get
			{
				return this.dic.Count;
			}
		}
		public static string TypeString
		{
			get
			{
				return "struct";
			}
		}
		public Struct()
		{
			this.dic = new Dictionary<string, Value>();
		}
		private bool TryGet(string name, out Value v)
		{
			return this.dic.TryGetValue(name, out v);
		}
		public Value TryGet(string name)
		{
			Value result = null;
			bool flag = this.dic.TryGetValue(name, out result);
			return result;
		}
		private void checktype<T>(Value v)
		{
			Type typeFromHandle = typeof(T);
			Type type = v.GetType();
			if (typeFromHandle != type)
			{
				string message = string.Format("Expected type {0} instead got {1}", typeFromHandle.Name, type.Name);
				throw new XmlRPCException(message);
			}
		}
		public T TryGet<T>(string name) where T : Value
		{
			Value value = this.TryGet(name);
			T result;
			if (value == null)
			{
				result = default(T);
			}
			else
			{
				this.checktype<T>(value);
				result = (T)((object)value);
			}
			return result;
		}
		public T Get<T>(string name, T defval) where T : Value
		{
			Value value = this.TryGet(name);
			T result;
			if (value == null)
			{
				result = defval;
			}
			else
			{
				this.checktype<T>(value);
				result = (T)((object)value);
			}
			return result;
		}
		public Value Get(string name)
		{
			Value value = this.TryGet(name);
			if (value == null)
			{
				string message = string.Format("Struct does not contains {0}", name);
				throw new XmlRPCException(message);
			}
			return value;
		}
		public T Get<T>(string name) where T : Value
		{
			Value value = this.Get(name);
			this.checktype<T>(value);
			return (T)((object)value);
		}
		public bool ContainsKey(string name)
		{
			return this.dic.ContainsKey(name);
		}
		public IEnumerator<KeyValuePair<string, Value>> GetEnumerator()
		{
			return this.dic.GetEnumerator();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
		protected override void AddToTypeEl(XElement parent)
		{
			foreach (KeyValuePair<string, Value> current in this)
			{
				XElement xElement = new XElement("member");
				parent.Add(xElement);
				XElement xElement2 = new XElement("name");
				xElement.Add(xElement2);
				xElement2.Value = current.Key;
				current.Value.AddXmlElement(xElement);
			}
		}
		public static Struct XmlToValue(XElement type_el)
		{
			List<XElement> list = type_el.Elements("member").ToList<XElement>();
			Struct @struct = new Struct();
			foreach (XElement current in list)
			{
				XElement element = current.GetElement("name");
				string value = element.Value;
				XElement element2 = current.GetElement("value");
				Value value2 = Value.ParseXml(element2);
				@struct[value] = value2;
			}
			return @struct;
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
				Struct @struct = obj as Struct;
				if (@struct == null)
				{
					result = false;
				}
				else
				{
					if (this.dic != @struct.dic)
					{
						if (this.dic.Count != @struct.dic.Count)
						{
							result = false;
						}
						else
						{
							foreach (KeyValuePair<string, Value> current in this)
							{
								Value obj2 = null;
								if (!@struct.TryGet(current.Key, out obj2))
								{
									result = false;
									return result;
								}
								if (!current.Value.Equals(obj2))
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
			return Struct.TypeString;
		}
		public override int GetHashCode()
		{
			return this.dic.GetHashCode();
		}
	}
}
