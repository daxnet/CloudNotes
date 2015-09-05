namespace CloudNotes.DesktopClient.Synchronization.Storage.UnifiedQueries
{
    /// <summary>
    /// Represents that the implemented classes are query specification compilers.
    /// </summary>
    public interface IQuerySpecificationCompiler
    {
        /// <summary>
        /// Compiles the specified query specification into another representation.
        /// </summary>
        /// <param name="querySpecification">The query specification needs to be compiled.</param>
        /// <returns>Another representation of the query specification.</returns>
        object Compile(QuerySpecification querySpecification);
    }

    /// <summary>
    /// Represents that the implemented classes are query specification compilers.
    /// </summary>
    /// <typeparam name="T">The type of the compiled representation.</typeparam>
    public interface IQuerySpecificationCompiler<out T> : IQuerySpecificationCompiler
    {
        /// <summary>
        /// Compiles the specified query specification into another representation.
        /// </summary>
        /// <param name="querySpecification">The query specification needs to be compiled.</param>
        /// <returns>Another representation of the query specification.</returns>
        new T Compile(QuerySpecification querySpecification);
    }
}
