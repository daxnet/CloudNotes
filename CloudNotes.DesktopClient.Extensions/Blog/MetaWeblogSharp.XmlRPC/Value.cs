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
	using System.Linq;
	using System.Xml.Linq;

	public abstract class Value
	{
		protected abstract void AddToTypeEl(XElement parent);
		protected abstract string GetTypeString();
		public static Value ParseXml(XElement value_el)
		{
			if (value_el.Name != "value")
			{
				string message = string.Format("XML Element should have name \"value\" instead found \"{0}\"", value_el.Name);
				throw new XmlRPCException();
			}
			string value = value_el.Value;
			Value result;
			if (value_el.HasElements)
			{
				XElement xElement = value_el.Elements().First<XElement>();
				string text = xElement.Name.ToString();
				if (text == Array.TypeString)
				{
					result = Array.XmlToValue(xElement);
				}
				else
				{
					if (text == Struct.TypeString)
					{
						result = Struct.XmlToValue(xElement);
					}
					else
					{
						if (text == StringValue.TypeString)
						{
							result = StringValue.XmlToValue(xElement);
						}
						else
						{
							if (text == DoubleValue.TypeString)
							{
								result = DoubleValue.XmlToValue(xElement);
							}
							else
							{
								if (text == Base64Data.TypeString)
								{
									result = Base64Data.XmlToValue(xElement);
								}
								else
								{
									if (text == DateTimeValue.TypeString)
									{
										result = DateTimeValue.XmlToValue(xElement);
									}
									else
									{
										if (text == IntegerValue.TypeString || text == IntegerValue.AlternateTypeString)
										{
											result = IntegerValue.XmlToValue(xElement);
										}
										else
										{
											if (text != BooleanValue.TypeString)
											{
												string message = string.Format("Unsupported type: {0}", text);
												throw new XmlRPCException(message);
											}
											result = BooleanValue.XmlToValue(xElement);
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				result = new StringValue(value);
			}
			return result;
		}
		public XElement AddXmlElement(XElement parent)
		{
			XElement xElement = new XElement("value");
			XElement xElement2 = new XElement(this.GetTypeString());
			xElement.Add(xElement2);
			this.AddToTypeEl(xElement2);
			parent.Add(xElement);
			return xElement;
		}
	}
}
