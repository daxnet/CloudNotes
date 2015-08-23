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

namespace CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp
{
	using System.Net;
	using System.Xml.Linq;

	public class BlogConnectionInfo
	{
		public CookieContainer Cookies = null;
		public string BlogURL
		{
			get;
			set;
		}
		public string MetaWeblogURL
		{
			get;
			set;
		}
		public string BlogID
		{
			get;
			set;
		}
		public string Username
		{
			get;
			set;
		}
		public string Password
		{
			get;
			set;
		}
		public static BlogConnectionInfo Load(string filename)
		{
			XDocument xDocument = XDocument.Load(filename);
			XElement root = xDocument.Root;
			string elementString = root.GetElementString("blogurl");
			string elementString2 = root.GetElementString("blogid");
			string elementString3 = root.GetElementString("metaweblog_url");
			string elementString4 = root.GetElementString("username");
			string elementString5 = root.GetElementString("password");
			return new BlogConnectionInfo(elementString, elementString3, elementString2, elementString4, elementString5);
		}
		public void Save(string filename)
		{
			XDocument xDocument = new XDocument();
			XElement xElement = new XElement("blogconnectioninfo");
			xDocument.Add(xElement);
			xElement.Add(new XElement("blogurl", this.BlogURL));
			xElement.Add(new XElement("blogid", this.BlogID));
			xElement.Add(new XElement("metaweblog_url", this.MetaWeblogURL));
			xElement.Add(new XElement("username", this.Username));
			xElement.Add(new XElement("password", this.Password));
			xDocument.Save(filename);
		}
		public BlogConnectionInfo(string blogurl, string metaweblogurl, string blogid, string username, string password)
		{
			this.BlogURL = blogurl;
			this.BlogID = blogid;
			this.MetaWeblogURL = metaweblogurl;
			this.Username = username;
			this.Password = password;
		}
		private BlogConnectionInfo() : this(null, null, null, null, null)
		{
		}
	}
}
