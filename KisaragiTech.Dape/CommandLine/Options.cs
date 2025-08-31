using CommandLine;

namespace KisaragiTech.Dape.CommandLine;

public class Options
{
    [Option("run-dir", Required = true)]
    public required string RunDir { get; set; }
}
