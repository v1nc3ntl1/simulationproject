using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patch
{
    using System.Text.RegularExpressions;
    using Sitecore.Diagnostics;
    using Sitecore.Pipelines.Search;
    using Sitecore.Search;
    using SolrNet.Impl.QuerySerializers;

    public class EscapeSpecialCharacters
    {
        public void Process(SearchArgs args)
        {
            Assert.ArgumentNotNull((object)args, "args");
            if (args.UseLegacySearchEngine || string.IsNullOrEmpty(args.TextQuery))
                return;
            string[] tokens = args.TextQuery.Split(' ');
            this.RemoveCharacters(tokens);
            this.EscapeCharacters(tokens);
            args.Query = new FullTextQuery(string.Join(" ", tokens));
        }

        public void RemoveCharacters(string[] tokens)
        {
            char[] chArray = new char[20]
            {
                '+',
                '-',
                '&',
                '|',
                '!',
                '{',
                '}',
                '[',
                ']',
                '^',
                '(',
                ')',
                '"',
                '~',
                ':',
                ';',
                '\\',
                '?',
                '*',
                '/'
            };
            for (int index = 0; index < Enumerable.Count<string>((IEnumerable<string>)tokens); ++index)
            {
                tokens[index] = tokens[index].TrimStart(chArray);
                tokens[index] = tokens[index].TrimEnd(chArray);
            }
        }

        public void EscapeCharacters(string[] tokens)
        {
            for (int index = 0; index < Enumerable.Count<string>((IEnumerable<string>)tokens); ++index)
            {
                if (!string.IsNullOrEmpty(tokens[index]))
                    tokens[index] = ((Regex)QueryByFieldSerializer.SpecialCharactersRx).Replace(tokens[index], "\\$1");
            }
        }
    }
}
