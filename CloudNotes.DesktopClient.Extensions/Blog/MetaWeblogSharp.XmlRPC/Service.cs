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
	using System.IO;
	using System.Net;
	using System.Text;
	using System.Threading.Tasks;
	using System.Xml.Linq;

	public class Service
	{
		private bool EnableExpect100Continue = false;
		public CookieContainer Cookies = null;
		public string URL
		{
			get;
			private set;
		}
		public Service(string url)
		{
			this.URL = url;
		}
		//public MethodResponse Execute(MethodCall methodcall)
		//{
		//    XDocument xDocument = methodcall.CreateDocument();
		//    WebRequest webRequest = WebRequest.Create(this.URL);
		//    if (this.Cookies != null)
		//    {
		//        HttpWebRequest httpWebRequest = webRequest as HttpWebRequest;
		//        httpWebRequest.CookieContainer = this.Cookies;
		//    }
		//    HttpWebRequest httpWebRequest2 = (HttpWebRequest)webRequest;
		//    httpWebRequest2.ServicePoint.Expect100Continue = this.EnableExpect100Continue;
		//    webRequest.Method = "POST";
		//    string s = xDocument.ToString();
		//    byte[] bytes = Encoding.UTF8.GetBytes(s);
		//    webRequest.ContentType = "text/xml;charset=utf-8";
		//    webRequest.ContentLength = (long)bytes.Length;
		//    using (Stream requestStream = webRequest.GetRequestStream())
		//    {
		//        requestStream.Write(bytes, 0, bytes.Length);
		//    }
		//    MethodResponse result;
		//    using (HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse())
		//    {
		//        using (Stream responseStream = httpWebResponse.GetResponseStream())
		//        {
		//            if (responseStream == null)
		//            {
		//                throw new XmlRPCException("Response Stream is unexpectedly null");
		//            }
		//            using (StreamReader streamReader = new StreamReader(responseStream))
		//            {
		//                string content = streamReader.ReadToEnd();
		//                MethodResponse methodResponse = new MethodResponse(content);
		//                result = methodResponse;
		//            }
		//        }
		//    }
		//    return result;
		//}

		public async Task<MethodResponse> ExecuteAsync(MethodCall methodCall)
		{
			var xDocument = methodCall.CreateDocument();
			var webRequest = WebRequest.Create(this.URL);
			if (this.Cookies != null)
			{
				var httpWebRequest = webRequest as HttpWebRequest;
				if (httpWebRequest != null)
				{
					httpWebRequest.CookieContainer = this.Cookies;
				}
			}
			var httpWebRequest2 = (HttpWebRequest)webRequest;
			httpWebRequest2.ServicePoint.Expect100Continue = this.EnableExpect100Continue;
			webRequest.Method = "POST";
			var s = xDocument.ToString();
			var bytes = Encoding.UTF8.GetBytes(s);
			webRequest.ContentType = "text/xml;charset=utf-8";
			webRequest.ContentLength = bytes.Length;
			using (var requestStream = await webRequest.GetRequestStreamAsync())
			{
				await requestStream.WriteAsync(bytes, 0, bytes.Length);
			}
			MethodResponse result;
			using (var httpWebResponse = (HttpWebResponse)await webRequest.GetResponseAsync())
			{
				using (var responseStream = httpWebResponse.GetResponseStream())
				{
					if (responseStream == null)
					{
						throw new XmlRPCException("Response Stream is unexpectedly null");
					}
					using (StreamReader streamReader = new StreamReader(responseStream))
					{
						string content = await streamReader.ReadToEndAsync();
						var methodResponse = new MethodResponse(content);
						result = methodResponse;
					}
				}
			}
			return result;
		}
	}
}
