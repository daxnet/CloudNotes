namespace CloudNotes.DesktopClient.Synchronization.Storage
{
    using System;

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    internal sealed class TableMappingAttribute : Attribute
    {
        public string TableName { get; set; }

        public TableMappingAttribute(string tableName)
        {
            this.TableName = tableName;
        }
    }
}
