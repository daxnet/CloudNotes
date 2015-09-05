namespace CloudNotes.DesktopClient.Synchronization.Storage.UnifiedQueries.Compilers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CloudNotes.DesktopClient.Synchronization.Storage.UnifiedQueries;

    /// <summary>
    /// Represents the query specification compiler which can compile the query specification
    /// into a WHERE clause of a SQL statement for RDBMS.
    /// </summary>
    public class SqlWhereClauseCompiler : QuerySpecificationCompiler<string>
    {
        /// <summary>
        /// The parameter values.
        /// </summary>
        private readonly Dictionary<string, object> parameterValues = new Dictionary<string, object>();

        /// <summary>
        /// The use parameter.
        /// </summary>
        private bool useParameter;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlWhereClauseCompiler"/> class.
        /// </summary>
        public SqlWhereClauseCompiler()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlWhereClauseCompiler"/> class.
        /// </summary>
        /// <param name="useParameter">A <see cref="Boolean"/> value which indicates whether the compiled
        /// WHERE clause should use the parameter styles, or simply use the values in the generated WHERE clause.</param>
        public SqlWhereClauseCompiler(bool useParameter)
        {
            this.useParameter = useParameter;
        }


        public IEnumerable<KeyValuePair<string, object>> ParameterValues
        {
            get
            {
                return this.parameterValues;
            }
        }

        public bool UseParameter
        {
            get
            {
                return this.useParameter;
            }

            set
            {
                this.useParameter = value;
            }
        }

        protected virtual char LikeSymbol
        {
            get
            {
                return '%';
            }
        }

        protected virtual char ParameterChar
        {
            get
            {
                return '@';
            }
        }

        protected virtual string GetExpressionPresentation(Expression expr)
        {
            var sb = new StringBuilder("(");
            sb.Append(expr.Name);
            switch (expr.Operator)
            {
                case RelationalOperators.Contains:
                case RelationalOperators.EndsWith:
                case RelationalOperators.StartsWith:
                    sb.Append(" LIKE ");
                    break;
                case RelationalOperators.EqualTo:
                    sb.Append(" = ");
                    break;
                case RelationalOperators.GreaterThan:
                    sb.Append(" > ");
                    break;
                case RelationalOperators.GreaterThanOrEqualTo:
                    sb.Append(" >= ");
                    break;
                case RelationalOperators.LessThan:
                    sb.Append(" < ");
                    break;
                case RelationalOperators.LessThanOrEqualTo:
                    sb.Append(" <= ");
                    break;
            }

            if (this.useParameter)
            {
                if (expr.Type == DataTypes.String)
                {
                    switch (expr.Operator)
                    {
                        case RelationalOperators.StartsWith:
                            expr.Value = string.Format("{0}{1}", expr.Value, this.LikeSymbol);
                            break;
                        case RelationalOperators.EndsWith:
                            expr.Value = string.Format("{0}{1}", this.LikeSymbol, expr.Value);
                            break;
                        default:
                            expr.Value = string.Format("{1}{0}{1}", expr.Value, this.LikeSymbol);
                            break;
                    }
                }

                var value = expr.GetValue();
                var parameterName = string.Format("{0}{1}", this.ParameterChar, Utils.GetUniqueIdentifier(6));
                this.parameterValues.Add(parameterName, value);
                sb.AppendFormat(parameterName);
            }
            else
            {
                switch (expr.Type)
                {
                    case DataTypes.Char:
                        sb.AppendFormat("'{0}'", expr.Value);
                        break;
                    case DataTypes.String:
                        switch (expr.Operator)
                        {
                            case RelationalOperators.StartsWith:
                                sb.AppendFormat("'{0}{1}'", expr.Value, this.LikeSymbol);
                                break;
                            case RelationalOperators.EndsWith:
                                sb.AppendFormat("'{0}{1}'", this.LikeSymbol, expr.Value);
                                break;
                            default:
                                sb.AppendFormat("'{1}{0}{1}'", expr.Value, this.LikeSymbol);
                                break;
                        }

                        break;
                    default:
                        sb.Append(expr.Value);
                        break;
                }
            }
            
            sb.Append(")");
            return sb.ToString();
        }

        /// <summary>
        /// Performs the compile.
        /// </summary>
        /// <param name="querySpecification">The query specification.</param>
        /// <returns></returns>
        protected override string PerformCompile(QuerySpecification querySpecification)
        {
            var objectStack = new Stack<object>();
            var queryStack = new Stack<string>();

            var visitor = new DelegatedQuerySpecificationVisitor(
                querySpecification,
                objectStack.Push,
                objectStack.Push,
                objectStack.Push);
            visitor.Visit();

            while (objectStack.Count > 0)
            {
                var item = objectStack.Pop();
                if (item is Expression)
                {
                    queryStack.Push(this.GetExpressionPresentation(item as Expression));
                }
                else if (item is UnaryLogicalOperation)
                {
                    var unaryLogicalOperation = item as UnaryLogicalOperation;
                    var cachedQuery = queryStack.Pop();
                    queryStack.Push(
                        string.Format("({0} {1})", unaryLogicalOperation.Operator.ToString().ToUpper(), cachedQuery));
                }
                else if (item is LogicalOperation)
                {
                    var logicalOperation = item as LogicalOperation;
                    var leftQuery = queryStack.Pop();
                    var rightQuery = queryStack.Pop();
                    queryStack.Push(
                        string.Format(
                            "({0} {1} {2})",
                            leftQuery,
                            logicalOperation.Operator.ToString().ToUpper(),
                            rightQuery));
                }
            }

            return queryStack.Pop();
        }
    }
}
