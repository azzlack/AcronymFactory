namespace AcronymFactory
{
    public interface IAcronymFactory
    {
        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <value>The options.</value>
        ICultureOptions Options { get; }

        /// <summary>
        /// Creates an acronym of the specified length from the specified source string.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="length">The length.</param>
        /// <param name="ci">The culture. <c>English</c> by default.</param>
        /// <returns>A human-readable key/password version of the source string.</returns>
        string Create(string source, int length = 8);
    }
}