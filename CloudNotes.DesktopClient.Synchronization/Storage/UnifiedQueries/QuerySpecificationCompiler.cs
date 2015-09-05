namespace CloudNotes.DesktopClient.Synchronization.Storage.UnifiedQueries
{
    using System;

    /// <summary>
    /// Represents the base class for query specification compilers.
    /// </summary>
    /// <typeparam name="T">The type of the compiled representation of the query specification.</typeparam>
    public abstract class QuerySpecificationCompiler<T> : IQuerySpecificationCompiler<T>
    {
        /// <summary>
        /// Compiles the specified query specification.
        /// </summary>
        /// <param name="querySpecification">The query specification.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">Can't compile the given query specificaiton as the validation was failed. See InnerException for details.</exception>
        public T Compile(QuerySpecification querySpecification)
        {
            try
            {
                QuerySpecificationValidator.Validate(querySpecification, true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "Can't compile the given query specificaiton as the validation was failed. See InnerException for details.",
                    ex);
            }

            return this.PerformCompile(querySpecification);
        }

        /// <summary>
        /// Compiles the specified query specification into another representation.
        /// </summary>
        /// <param name="querySpecification">The query specification needs to be compiled.</param>
        /// <returns>
        /// Another representation of the query specification.
        /// </returns>
        object IQuerySpecificationCompiler.Compile(QuerySpecification querySpecification)
        {
            return this.Compile(querySpecification);
        }

        /// <summary>
        /// Compiles the specified query specification into another representation.
        /// </summary>
        /// <param name="querySpecification">The query specification needs to be compiled.</param>
        /// <returns>Another representation of the query specification.</returns>
        protected abstract T PerformCompile(QuerySpecification querySpecification);
    }
}
