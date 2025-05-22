using System;
using System.Linq;
using CommandLine;

namespace KisaragiTech.Dape.CommandLine;

public static class ParserResultExtensions
{
    public static T GetOrThrow<T>(this ParserResult<T> self)
    {
        if (self.Tag == ParserResultType.NotParsed)
        {
            throw new AggregateException(self.Errors.Select(e => new CommandLineItemParseException(e)));
        }

        return self.Value;
    }
}