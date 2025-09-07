using Microsoft.Extensions.Configuration;

namespace DotEnvConfigProvider;

/// <summary>
/// Represents a .env file as an <see cref="IConfigurationSource"/>.
/// </summary>
public sealed class DotEnvConfigurationSource 
    : FileConfigurationSource
{
    /// <summary>
    /// Builds the <see cref="DotEnvConfigurationProvider"/> for this source.
    /// </summary>
    /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
    /// <returns>A <see cref="DotEnvConfigurationProvider"/></returns>
    public override IConfigurationProvider Build(
        IConfigurationBuilder builder)
    {
        EnsureDefaults(builder);

        return new DotEnvConfigurationProvider(this);
    }
}
