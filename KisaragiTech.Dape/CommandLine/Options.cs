using CommandLine;

namespace KisaragiTech.Dape.CommandLine;

public class Options
{
    [Option("run-dir", Required = true)]
    public string RunDir { get; set; }
}