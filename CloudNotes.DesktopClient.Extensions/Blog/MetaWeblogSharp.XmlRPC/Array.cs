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
