// ReSharper disable CheckNamespace
namespace CloudNotes.DesktopClient.Synchronization.Storage.UnifiedQueries
    // ReSharper restore CheckNamespace
{
    public partial class UnaryLogicalOperation
    {
        public override string ToString()
        {
            return string.Format("({0} {1})", this.Operator, this.Item);
        }
    }
}
