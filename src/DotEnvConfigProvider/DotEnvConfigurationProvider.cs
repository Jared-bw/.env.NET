using Microsoft.Extensions.Configuration;

namespace DotEnvConfigProvider;

/// <summary>
/// A .env file-based <see cref="FileConfigurationProvider"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance with the specified <paramref name="source"/>.
/// </remarks>
/// <param name="source">The .env configuration source.</param>
internal sealed class DotEnvConfigurationProvider(
    DotEnvConfigurationSource source) : FileConfigurationProvider(source)
{
    /// <summary>
    /// Loads the .env data from a stream.
    /// </summary>
    /// <param name="stream">The stream to read.</param>
    public override void Load(Stream stream)
    {
        try
        {
            Data = DotEnvConfigurationFileParser.Parse(stream);
        }
        catch (Exception ex)
        {
            throw new FormatException(
                "Unable to parse '.env' file", ex);
        }
    }
}
