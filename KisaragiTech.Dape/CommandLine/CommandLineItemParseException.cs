using System;
using CommandLine;

namespace KisaragiTech.Dape.CommandLine;

public class CommandLineItemParseException(Error error) : Exception
{
    public override string ToString()
    {
        return $"{error.Tag}: {error}";
    }
};
