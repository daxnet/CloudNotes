//  =======================================================================================================
// 
//     ,uEZGZX  LG                             Eu       iJ       vi                                              
//    BB7.  .:  uM                             8F       0BN      Bq             S:                               
//   @X         LO    rJLYi    :     i    iYLL XJ       Xu7@     Mu    7LjL;   rBOii   7LJ7    .vYUi             
//  ,@          LG  7Br...SB  vB     B   B1...7BL       0S i@,   OU  :@7. ,u@   @u.. :@:  ;B  LB. ::             
//  v@          LO  B      Z0 i@     @  BU     @Y       qq  .@L  Oj  @      5@  Oi   @.    MB U@                 
//  .@          JZ :@      :@ rB     B  @      5U       Eq    @0 Xj ,B      .B  Br  ,B:rv777i  :0ZU              
//   @M         LO  @      Mk :@    .@  BL     @J       EZ     GZML  @      XM  B;   @            Y@             
//    ZBFi::vu  1B  ;B7..:qO   BS..iGB   BJ..:vB2       BM      rBj  :@7,.:5B   qM.. i@r..i5. ir. UB             
//      iuU1vi   ,    ;LLv,     iYvi ,    ;LLr  .       .,       .     rvY7:     rLi   7LLr,  ,uvv:  
// 
// 
//  Copyright 2014-2015 daxnet
//  
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  
//      http://www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  =======================================================================================================

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
