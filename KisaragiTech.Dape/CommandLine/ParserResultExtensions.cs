using System;
using System.Linq;
using CommandLine;

namespace KisaragiTech.Dape.CommandLine;

public static class ParserResultExtensions
{
    public static T GetOrThrow<T>(this ParserResult<T> self)
    {
        if (self.Tag == ParserResultType.NotParsed && self.Errors.Any(NotMetaSwitchRequestedError))
        {
            throw new AggregateException(self.Errors
                .Where(NotMetaSwitchRequestedError)
                .Select(e => new CommandLineItemParseException(e)));
        }

        return self.Value;
    }

    private static bool NotMetaSwitchRequestedError(Error e) => e.Tag is not ErrorType.HelpRequestedError and not ErrorType.VersionRequestedError;
}
