
namespace CloudNotes.DesktopClient.Synchronization.Storage.UnifiedQueries
{
    using System;

    public class DelegatedQuerySpecificationVisitor : QuerySpecificationVisitor
    {
        private readonly Action<Expression> visitExpression;

        private readonly Action<LogicalOperation> visitLogicalOperation;

        private readonly Action<UnaryLogicalOperation> visitUnaryLogicalOperation;

        public DelegatedQuerySpecificationVisitor(
            QuerySpecification querySpecification,
            Action<Expression> visitExpression,
            Action<LogicalOperation> visitLogicalOperation,
            Action<UnaryLogicalOperation> visitUnaryLogicalOperation)
            : base(querySpecification)
        {
            this.visitExpression = visitExpression;
            this.visitLogicalOperation = visitLogicalOperation;
            this.visitUnaryLogicalOperation = visitUnaryLogicalOperation;
        }

        protected override void VisitExpression(Expression expression)
        {
            if (this.visitExpression != null)
            {
                this.visitExpression(expression);
            }
        }

        protected override void VisitLogicalOperation(LogicalOperation logicalOperation)
        {
            if (this.visitLogicalOperation != null)
            {
                this.visitLogicalOperation(logicalOperation);
            }
        }

        protected override void VisitUnaryLogicalOperation(UnaryLogicalOperation unaryLogicalOperation)
        {
            if (this.visitUnaryLogicalOperation != null)
            {
                this.visitUnaryLogicalOperation(unaryLogicalOperation);
            }
        }
    }
}
