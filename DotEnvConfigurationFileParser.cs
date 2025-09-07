namespace DotEnvConfigProvider;

internal sealed class DotEnvConfigurationFileParser
{
    private DotEnvConfigurationFileParser() { }

    private readonly Dictionary<string, string?> _data = 
        new(StringComparer.OrdinalIgnoreCase);

    public static IDictionary<string, string?> Parse(Stream input) =>
        new DotEnvConfigurationFileParser().ParseStream(input);

    private Dictionary<string, string?> ParseStream(Stream input)
    {
        using TextReader reader = new StreamReader(input);

        var line = reader.ReadLine();
        while (line is not null)
        {
            var data = line.Split('=', 2, StringSplitOptions.TrimEntries);
            var key =  data[0];
            var value = data[1];
            _data.Add(key, value);
            
            line = reader.ReadLine();
        }

        return _data;
    }
}
