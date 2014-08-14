namespace AcronymFactory
{
    using System.Collections.Generic;

    public class EnglishCultureOptions : ICultureOptions
    {
        /// <summary>
        /// Gets the words to ignore.
        /// </summary>
        /// <value>The words words to ignore.</value>
        public IEnumerable<string> IgnoreWords
        {
            get
            {
                return new[] { "THE", "A", "AN", "AS", "AND", "OF", "OR" };
            }
        }

        /// <summary>
        /// Gets the vowels.
        /// </summary>
        /// <value>The vowels.</value>
        public IEnumerable<char> Vowels
        {
            get
            {
                return new[] { 'A', 'E', 'I', 'O', 'U', 'Y' };
            }
        }

        /// <summary>
        /// Gets the characters that should be mapped to a different character.
        /// </summary>
        /// <value>The character mapping.</value>
        public IDictionary<int, string> CharacterMapping
        {
            get
            {
                return new Dictionary<int, string>()
                           {
                               { 199, "C" },
                               { 231, "c" },
                               { 252, "u" },
                               { 251, "u" },
                               { 250, "u" },
                               { 249, "u" },
                               { 233, "e" },
                               { 234, "e" },
                               { 235, "e" },
                               { 232, "e" },
                               { 226, "a" },
                               { 228, "a" },
                               { 224, "a" },
                               { 229, "a" },
                               { 225, "a" },
                               { 239, "i" },
                               { 238, "i" },
                               { 236, "i" },
                               { 237, "i" },
                               { 196, "A" },
                               { 197, "A" },
                               { 201, "E" },
                               { 230, "ae" },
                               { 198, "Ae" },
                               { 244, "o" },
                               { 246, "o" },
                               { 242, "o" },
                               { 243, "o" },
                               { 220, "U" },
                               { 255, "Y" },
                               { 214, "O" },
                               { 241, "n" },
                               { 209, "N" }
                           };
            }
        }
    }
}