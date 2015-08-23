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
