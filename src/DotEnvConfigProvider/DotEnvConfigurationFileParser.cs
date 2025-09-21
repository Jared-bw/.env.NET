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
                var commentStartIndex = line.IndexOf('#');
                var configLength = commentStartIndex == -1 ? line.Length : commentStartIndex;
                
                var config = line.AsSpan(0, configLength);
                
                var equalsIndex = config.IndexOf('=');
                var key = config.Slice(0, equalsIndex).ToString();
                var value = config.Slice(equalsIndex + 1, config.Length - equalsIndex - 1).ToString();
                
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