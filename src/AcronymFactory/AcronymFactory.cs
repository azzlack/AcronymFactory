namespace AcronymFactory
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class AcronymFactory : IAcronymFactory
    {
        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <value>The options.</value>
        public ICultureOptions Options { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AcronymFactory"/> class.
        /// </summary>
        public AcronymFactory()
        {
            this.Options = new EnglishCultureOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AcronymFactory"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public AcronymFactory(ICultureOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            this.Options = options;
        }

        /// <summary>
        /// Creates an acronym of the specified length from the specified source string.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="length">The length.</param>
        /// <param name="ci">The culture. <c>English</c> by default.</param>
        /// <returns>A human-readable key/password version of the source string.</returns>
        public string Create(string source, int length = 8)
        {
            // Strip whitespace at beginning and end
            source = source.Trim();

            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }

            // Replace some characters with hard-coded values
            var a = new List<string>();

            for (var d = 0; d < source.Length; d++)
            {
                if (this.Options.CharacterMapping.ContainsKey(source[d]))
                {
                    a.Add(this.Options.CharacterMapping[source[d]]);
                }
                else
                {
                    a.Add(source[d].ToString());
                }
            }

            // Create word list
            source = string.Join(string.Empty, a);

            var words = new List<string>();

            foreach (var group in Regex.Split(source, @"\s+"))
            {
                var k = Regex.Replace(group, @"[^a-zA-Z]", string.Empty);
                k = k.ToUpperInvariant();

                if (!string.IsNullOrEmpty(k))
                {
                    words.Add(k);
                }
            }

            // Remove ignored words
            if (words.Count() > length)
            {
                words = words.Where(x => !this.Options.IgnoreWords.Contains(x)).ToList();
            }

            var result = string.Empty;

            // Create acronym
            if (words.Any())
            {
                if (words.Count() == 1)
                {
                    var g = words[0];

                    if (g.Length > length)
                    {
                        result = this.GetFirstSyllable(g, length);
                    }
                    else
                    {
                        result = g;
                    }
                }
                else
                {
                    result = this.CreateAcronym(words, length);
                }
            }

            // Shorten acronym if too long
            if (result.Length > length)
            {
                return result.Substring(0, length);
            }
            
            return result;
        }

        /// <summary>
        /// Creates an acronym from the specified words.
        /// </summary>
        /// <param name="words">The words.</param>
        /// <param name="length">The length.</param>
        /// <returns>An acronym.</returns>
        private string CreateAcronym(IEnumerable<string> words, int length)
        {
            var a = string.Empty;

            var charsPerWord = (int)Math.Ceiling((double)length / words.Count());
            var lastUsed = charsPerWord;

            foreach (var word in words)
            {
                var l = charsPerWord + (charsPerWord - lastUsed);

                if (word.Length < l)
                {
                    a += word;
                    lastUsed = word.Length;
                }
                else
                {
                    a += word.Substring(0, l);
                    lastUsed = l;
                }
            }

            return a;
        }

        /// <summary>
        /// Gets the first syllable.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="length">The length.</param>
        /// <returns>The first syllable.</returns>
        private string GetFirstSyllable(string source, int length)
        {
            var b = false;

            for (var a = 0; a < source.Length; a++)
            {
                if (this.Options.Vowels.Contains(source[a]))
                {
                    b = true;
                }
                else
                {
                    if (b && (a + 1) == length)
                    {
                        return source.Substring(0, a + 1);
                    }
                }
            }

            return source;
        }
    }
}