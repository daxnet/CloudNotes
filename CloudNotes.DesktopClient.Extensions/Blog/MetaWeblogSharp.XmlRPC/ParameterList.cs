namespace CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp.XmlRPC
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ParameterList : IEnumerable<Value>, IEnumerable
	{
		private List<Value> Parameters;
		public Value this[int index]
		{
			get
			{
				return this.Parameters[index];
			}
		}
		public int Count
		{
			get
			{
				return this.Parameters.Count;
			}
		}
		public ParameterList()
		{
			this.Parameters = new List<Value>();
		}
		public void Add(Value value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			this.Parameters.Add(value);
		}
		public void Add(int value)
		{
			this.Add(new IntegerValue(value));
		}
		public void Add(bool value)
		{
			this.Add(new BooleanValue(value));
		}
		public void Add(DateTime value)
		{
			this.Add(new DateTimeValue(value));
		}
		public void Add(double value)
		{
			this.Add(new DoubleValue(value));
		}
		public void Add(Array value)
		{
			this.Parameters.Add(value);
		}
		public void Add(Struct value)
		{
			this.Parameters.Add(value);
		}
		public void Add(Base64Data value)
		{
			this.Parameters.Add(value);
		}
		public void Add(string value)
		{
			this.Add(new StringValue(value));
		}
		public IEnumerator<Value> GetEnumerator()
		{
			return this.Parameters.GetEnumerator();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}
