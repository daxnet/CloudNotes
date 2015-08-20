namespace CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp.XmlRPC
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
	public class XmlRPCException : Exception
	{
		public Fault Fault;
		public XmlRPCException()
		{
		}
		public XmlRPCException(string message) : base(message)
		{
		}
		public XmlRPCException(string message, Exception inner) : base(message, inner)
		{
		}
		protected XmlRPCException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
