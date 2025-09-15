using System;
using CommandLine;

namespace KisaragiTech.Dape.CommandLine;

public class CommandLineItemParseException(Error error) : Exception
{
    public override string ToString() => $"{error.Tag}: {error} (tag={error.Tag}, stop process={error.StopsProcessing})";
}
