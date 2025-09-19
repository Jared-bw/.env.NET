namespace DotEnvConfigProvider;

internal static class DotEnvConfigurationFileParser
{
    public static IDictionary<string, string?> Parse(Stream input)
    {
        using TextReader reader = new StreamReader(input);

        var data = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
        var line = reader.ReadLine();
        while (line is not null)
        {
            try
            {
                var lineData = line.Split('=', 2, StringSplitOptions.TrimEntries);
                var key = lineData[0];
                var value = lineData[1];
                data.Add(key, value);
            }
            catch 
            {
                // Ignore malformed lines
            }

            line = reader.ReadLine();
        }

        return data;
    }
}