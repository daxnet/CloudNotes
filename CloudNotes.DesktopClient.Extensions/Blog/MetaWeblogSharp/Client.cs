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
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp.XmlRPC;

	public class Client
	{
		public string AppKey = "0123456789ABCDEF";
		public BlogConnectionInfo BlogConnectionInfo;
		public Client(BlogConnectionInfo connectionInfo)
		{
			this.BlogConnectionInfo = connectionInfo;
		}
		public async Task<List<PostInfo>> GetRecentPostsAsync(int numposts)
		{
			Service service = new Service(this.BlogConnectionInfo.MetaWeblogURL);
			MethodCall methodCall = new MethodCall("metaWeblog.getRecentPosts");
			methodCall.Parameters.Add(this.BlogConnectionInfo.BlogID);
			methodCall.Parameters.Add(this.BlogConnectionInfo.Username);
			methodCall.Parameters.Add(this.BlogConnectionInfo.Password);
			methodCall.Parameters.Add(numposts);
			service.Cookies = this.BlogConnectionInfo.Cookies;
			MethodResponse methodResponse = await service.ExecuteAsync(methodCall);
			Value value = methodResponse.Parameters[0];
			XmlRPC.Array array = (XmlRPC.Array)value;
			List<PostInfo> list = new List<PostInfo>();
			foreach (Value current in array)
			{
				Struct @struct = (Struct)current;
				list.Add(new PostInfo
				{
					Title = @struct.Get<StringValue>("title", StringValue.NullString).String,
					DateCreated = new DateTime?(@struct.Get<DateTimeValue>("dateCreated").Data),
					Link = @struct.Get<StringValue>("link", StringValue.NullString).String,
					PostID = @struct.Get<StringValue>("postid", StringValue.NullString).String,
					UserID = @struct.Get<StringValue>("userid", StringValue.NullString).String,
					CommentCount = @struct.Get<IntegerValue>("commentCount", 0).Integer,
					PostStatus = @struct.Get<StringValue>("post_status", StringValue.NullString).String,
					PermaLink = @struct.Get<StringValue>("permaLink", StringValue.NullString).String,
					Description = @struct.Get<StringValue>("description", StringValue.NullString).String
				});
			}
			return list;
		}
		public async Task<MediaObjectInfo> NewMediaObjectAsync(string name, string type, byte[] bits)
		{
			Service service = new Service(this.BlogConnectionInfo.MetaWeblogURL);
			Struct @struct = new Struct();
			@struct["name"] = new StringValue(name);
			@struct["type"] = new StringValue(type);
			@struct["bits"] = new Base64Data(bits);
			MethodCall methodCall = new MethodCall("metaWeblog.newMediaObject");
			methodCall.Parameters.Add(this.BlogConnectionInfo.BlogID);
			methodCall.Parameters.Add(this.BlogConnectionInfo.Username);
			methodCall.Parameters.Add(this.BlogConnectionInfo.Password);
			methodCall.Parameters.Add(@struct);
			service.Cookies = this.BlogConnectionInfo.Cookies;
			MethodResponse methodResponse = await service.ExecuteAsync(methodCall);
			Value value = methodResponse.Parameters[0];
			Struct struct2 = (Struct)value;
			return new MediaObjectInfo
			{
				URL = struct2.Get<StringValue>("url", StringValue.NullString).String
			};
		}
		public async Task<PostInfo> GetPostAsync(string postid)
		{
			Service service = new Service(this.BlogConnectionInfo.MetaWeblogURL);
			MethodCall methodCall = new MethodCall("metaWeblog.getPost");
			methodCall.Parameters.Add(postid);
			methodCall.Parameters.Add(this.BlogConnectionInfo.Username);
			methodCall.Parameters.Add(this.BlogConnectionInfo.Password);
			service.Cookies = this.BlogConnectionInfo.Cookies;
			MethodResponse methodResponse = await service.ExecuteAsync(methodCall);
			Value value = methodResponse.Parameters[0];
			Struct @struct = (Struct)value;
			PostInfo postinfo = new PostInfo();
			postinfo.PostID = @struct.Get<StringValue>("postid").String;
			postinfo.Description = @struct.Get<StringValue>("description").String;
			postinfo.Link = @struct.Get<StringValue>("link", StringValue.NullString).String;
			postinfo.DateCreated = new DateTime?(@struct.Get<DateTimeValue>("dateCreated").Data);
			postinfo.PermaLink = @struct.Get<StringValue>("permaLink", StringValue.NullString).String;
			postinfo.PostStatus = @struct.Get<StringValue>("post_status", StringValue.NullString).String;
			postinfo.Title = @struct.Get<StringValue>("title").String;
			postinfo.UserID = @struct.Get<StringValue>("userid", StringValue.NullString).String;
			XmlRPC.Array source = @struct.Get<global::CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp.XmlRPC.Array>("categories");
			source.ToList<Value>().ForEach(delegate(Value i)
			{
				if (i is StringValue)
				{
					string @string = (i as StringValue).String;
					if (@string != "" && !postinfo.Categories.Contains(@string))
					{
						postinfo.Categories.Add(@string);
					}
				}
			});
			return postinfo;
		}
		public async Task<string> NewPostAsync(PostInfo pi, IList<string> categories, bool publish)
		{
			return await this.NewPostAsync(pi.Title, pi.Description, categories, publish, pi.DateCreated);
		}
		public async Task<string> NewPostAsync(string title, string description, IList<string> categories, bool publish, DateTime? date_created)
		{
			XmlRPC.Array array;
			if (categories == null)
			{
				array = new XmlRPC.Array(0);
			}
			else
			{
				array = new XmlRPC.Array(categories.Count);
				List<Value> ss = new List<Value>();
				(
					from c in categories
					select new StringValue(c)).ToList<StringValue>().ForEach(delegate(StringValue i)
				{
					ss.Add(i);
				});
				array.AddRange(ss);
			}
			Service service = new Service(this.BlogConnectionInfo.MetaWeblogURL);
			Struct @struct = new Struct();
			@struct["title"] = new StringValue(title);
			@struct["description"] = new StringValue(description);
			@struct["categories"] = array;
			if (date_created.HasValue)
			{
				@struct["dateCreated"] = new DateTimeValue(date_created.Value);
				@struct["date_created_gmt"] = new DateTimeValue(date_created.Value.ToUniversalTime());
			}
			MethodCall methodCall = new MethodCall("metaWeblog.newPost");
			methodCall.Parameters.Add(this.BlogConnectionInfo.BlogID);
			methodCall.Parameters.Add(this.BlogConnectionInfo.Username);
			methodCall.Parameters.Add(this.BlogConnectionInfo.Password);
			methodCall.Parameters.Add(@struct);
			methodCall.Parameters.Add(publish);
			service.Cookies = this.BlogConnectionInfo.Cookies;
			MethodResponse methodResponse = await service.ExecuteAsync(methodCall);
			Value value = methodResponse.Parameters[0];
			return ((StringValue)value).String;
		}
		public async Task<bool> DeletePostAsync(string postid)
		{
			Service service = new Service(this.BlogConnectionInfo.MetaWeblogURL);
			MethodCall methodCall = new MethodCall("blogger.deletePost");
			methodCall.Parameters.Add(this.AppKey);
			methodCall.Parameters.Add(postid);
			methodCall.Parameters.Add(this.BlogConnectionInfo.Username);
			methodCall.Parameters.Add(this.BlogConnectionInfo.Password);
			methodCall.Parameters.Add(true);
			service.Cookies = this.BlogConnectionInfo.Cookies;
			MethodResponse methodResponse = await service.ExecuteAsync(methodCall);
			Value value = methodResponse.Parameters[0];
			BooleanValue booleanValue = (BooleanValue)value;
			return booleanValue.Boolean;
		}
		public async Task<List<BlogInfo>> GetUsersBlogsAsync()
		{
			Service service = new Service(this.BlogConnectionInfo.MetaWeblogURL);
			MethodCall methodCall = new MethodCall("blogger.getUsersBlogs");
			methodCall.Parameters.Add(this.AppKey);
			methodCall.Parameters.Add(this.BlogConnectionInfo.Username);
			methodCall.Parameters.Add(this.BlogConnectionInfo.Password);
			service.Cookies = this.BlogConnectionInfo.Cookies;
			MethodResponse methodResponse = await service.ExecuteAsync(methodCall);
			XmlRPC.Array array = (XmlRPC.Array)methodResponse.Parameters[0];
			List<BlogInfo> list = new List<BlogInfo>(array.Count);
			for (int i = 0; i < array.Count; i++)
			{
				Struct @struct = (Struct)array[i];
				list.Add(new BlogInfo
				{
					BlogID = @struct.Get<StringValue>("blogid", StringValue.NullString).String,
					URL = @struct.Get<StringValue>("url", StringValue.NullString).String,
					BlogName = @struct.Get<StringValue>("blogName", StringValue.NullString).String,
					IsAdmin = @struct.Get<BooleanValue>("isAdmin", false).Boolean,
					SiteName = @struct.Get<StringValue>("siteName", StringValue.NullString).String,
					Capabilities = @struct.Get<StringValue>("capabilities", StringValue.NullString).String,
					XmlRPCEndPoint = @struct.Get<StringValue>("xmlrpc", StringValue.NullString).String
				});
			}
			return list;
		}
		public async Task<bool> EditPostAsync(string postid, string title, string description, IList<string> categories, bool publish)
		{
			XmlRPC.Array array = new XmlRPC.Array((categories == null) ? 0 : categories.Count);
			if (categories != null)
			{
				List<string> list = categories.Distinct<string>().ToList<string>();
				list.Sort();
				List<Value> ss = new List<Value>();
				(
					from c in list
					select new StringValue(c)).ToList<StringValue>().ForEach(delegate(StringValue i)
				{
					ss.Add(i);
				});
				array.AddRange(ss);
			}
			Service service = new Service(this.BlogConnectionInfo.MetaWeblogURL);
			Struct @struct = new Struct();
			@struct["title"] = new StringValue(title);
			@struct["description"] = new StringValue(description);
			@struct["categories"] = array;
			MethodCall methodCall = new MethodCall("metaWeblog.editPost");
			methodCall.Parameters.Add(postid);
			methodCall.Parameters.Add(this.BlogConnectionInfo.Username);
			methodCall.Parameters.Add(this.BlogConnectionInfo.Password);
			methodCall.Parameters.Add(@struct);
			methodCall.Parameters.Add(publish);
			service.Cookies = this.BlogConnectionInfo.Cookies;
			MethodResponse methodResponse = await service.ExecuteAsync(methodCall);
			Value value = methodResponse.Parameters[0];
			BooleanValue booleanValue = (BooleanValue)value;
			return booleanValue.Boolean;
		}
		public async Task<List<CategoryInfo>> GetCategoriesAsync()
		{
			Service service = new Service(this.BlogConnectionInfo.MetaWeblogURL);
			MethodCall methodCall = new MethodCall("metaWeblog.getCategories");
			methodCall.Parameters.Add(this.BlogConnectionInfo.BlogID);
			methodCall.Parameters.Add(this.BlogConnectionInfo.Username);
			methodCall.Parameters.Add(this.BlogConnectionInfo.Password);
			service.Cookies = this.BlogConnectionInfo.Cookies;
			MethodResponse methodResponse = await service.ExecuteAsync(methodCall);
			Value value = methodResponse.Parameters[0];
			global::CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp.XmlRPC.Array array = (global::CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp.XmlRPC.Array)value;
			List<CategoryInfo> list = new List<CategoryInfo>();
			foreach (Value current in array)
			{
				Struct @struct = (Struct)current;
				list.Add(new CategoryInfo
				{
					Title = @struct.Get<StringValue>("title", StringValue.NullString).String,
					Description = @struct.Get<StringValue>("description", StringValue.NullString).String,
					HTMLURL = @struct.Get<StringValue>("htmlUrl", StringValue.NullString).String,
					RSSURL = @struct.Get<StringValue>("rssUrl", StringValue.NullString).String,
					CategoryID = @struct.Get<StringValue>("categoryid", StringValue.NullString).String
				});
			}
			return list;
		}
		public async Task<UserInfo> GetUserInfoAsync()
		{
			Service service = new Service(this.BlogConnectionInfo.MetaWeblogURL);
			MethodCall methodCall = new MethodCall("blogger.getUserInfo");
			methodCall.Parameters.Add(this.AppKey);
			methodCall.Parameters.Add(this.BlogConnectionInfo.Username);
			methodCall.Parameters.Add(this.BlogConnectionInfo.Password);
			service.Cookies = this.BlogConnectionInfo.Cookies;
			MethodResponse methodResponse = await service.ExecuteAsync(methodCall);
			Value value = methodResponse.Parameters[0];
			Struct @struct = (Struct)value;
			return new UserInfo
			{
				UserID = @struct.Get<StringValue>("userid", StringValue.NullString).String,
				Nickname = @struct.Get<StringValue>("nickname", StringValue.NullString).String,
				FirstName = @struct.Get<StringValue>("firstname", StringValue.NullString).String,
				LastName = @struct.Get<StringValue>("lastname", StringValue.NullString).String,
				URL = @struct.Get<StringValue>("url", StringValue.NullString).String
			};
		}
	}
}
