namespace CloudNotes.DesktopClient.Synchronization.Storage.UnifiedQueries
{
    using System;

    public abstract class QuerySpecificationVisitor
    {
        private readonly QuerySpecification querySpecification;

        protected QuerySpecificationVisitor(QuerySpecification querySpecification)
        {
            this.querySpecification = querySpecification;
        }

        protected QuerySpecification QuerySpecification
        {
            get { return this.querySpecification; }
        }

        public void Visit()
        {
            if (this.querySpecification.Item == null)
            {
                throw new InvalidOperationException(
                    "Can't visit the query specification as there is no items defined under it.");
            }

            this.ProcessItem(this.querySpecification.Item);
        }

        protected abstract void VisitExpression(Expression expression);

        protected abstract void VisitLogicalOperation(LogicalOperation logicalOperation);

        protected abstract void VisitUnaryLogicalOperation(UnaryLogicalOperation unaryLogicalOperation);

        private void ProcessItem(object item)
        {
            if (item is Expression)
            {
                this.VisitExpression(item as Expression);
            }
            else if (item is LogicalOperation)
            {
                this.ProcessOperation(item as LogicalOperation);
            }
            else if (item is UnaryLogicalOperation)
            {
                this.ProcessOperation(item as UnaryLogicalOperation);
            }
            else
            {
                throw new InvalidOperationException(
                    "Can't process the item under query specification as its type is neither Expression, LogicalOperation, nor UnaryLogicalOperation.");
            }
        }

        private void ProcessOperation(UnaryLogicalOperation unaryLogicalOperation)
        {
            this.VisitUnaryLogicalOperation(unaryLogicalOperation);
            this.ProcessItem(unaryLogicalOperation.Item);
        }

        private void ProcessOperation(LogicalOperation logicalOperation)
        {
            this.VisitLogicalOperation(logicalOperation);
            this.ProcessItem(logicalOperation.Item);
            this.ProcessItem(logicalOperation.Item1);
        }
    }
}
