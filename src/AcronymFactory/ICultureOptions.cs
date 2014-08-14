namespace AcronymFactory
{
    using System.Collections.Generic;

    public interface ICultureOptions
    {
        /// <summary>
        /// Gets the words to ignore.
        /// </summary>
        /// <value>The words words to ignore.</value>
        IEnumerable<string> IgnoreWords { get; }

        /// <summary>
        /// Gets the vowels.
        /// </summary>
        /// <value>The vowels.</value>
        IEnumerable<char> Vowels { get; }
            
        /// <summary>
        /// Gets the characters that should be mapped to a different character.
        /// </summary>
        /// <value>The character mapping.</value>
        IDictionary<int, string> CharacterMapping { get; }
    }
}