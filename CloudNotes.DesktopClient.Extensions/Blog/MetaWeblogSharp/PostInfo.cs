namespace CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    public class PostInfo
	{
		public List<string> Categories = new List<string>();
		public string Title
		{
			get;
			set;
		}
		public string Link
		{
			get;
			set;
		}
		public DateTime? DateCreated
		{
			get;
			set;
		}
		public string PostID
		{
			get;
			set;
		}
		public string UserID
		{
			get;
			set;
		}
		public int CommentCount
		{
			get;
			set;
		}
		public string PostStatus
		{
			get;
			set;
		}
		public string PermaLink
		{
			get;
			set;
		}
		public string Description
		{
			get;
			set;
		}
		public static void Serialize(PostInfo[] posts, string filename)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(PostInfo[]));
			StreamWriter streamWriter = new StreamWriter(filename);
			xmlSerializer.Serialize(streamWriter, posts);
			streamWriter.Close();
		}
		public static PostInfo[] Deserialize(string filename)
		{
			StreamReader streamReader = File.OpenText(filename);
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(PostInfo[]));
			PostInfo[] result = (PostInfo[])xmlSerializer.Deserialize(streamReader);
			streamReader.Close();
			return result;
		}
	}
}
