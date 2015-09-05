// ReSharper disable CheckNamespace
namespace CloudNotes.DesktopClient.Synchronization.Storage.UnifiedQueries
    // ReSharper restore CheckNamespace
{
    public partial class LogicalOperation
    {
        public override string ToString()
        {
            return string.Format("({0} {1} {2})", this.Item, this.Operator, this.Item1);
        }
    }
}
