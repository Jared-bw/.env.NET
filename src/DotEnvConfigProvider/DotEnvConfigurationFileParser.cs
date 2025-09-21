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
                var equalsIndex = line.IndexOf('=');
                var key = line.Substring(0, equalsIndex);
                var value = line.Substring(equalsIndex + 1, line.Length - equalsIndex - 1);
                
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