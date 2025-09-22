using DotEnvConfigProvider;
using Microsoft.Extensions.FileProviders;

namespace Microsoft.Extensions.Configuration;

/// <summary>
/// Extension methods for adding <see cref="DotEnvConfigurationProvider"/>.
/// </summary>
public static class DotEnvConfigurationBuilderExtensions
{
    /// <summary>
    /// Adds the dotenv configuration provider .env
    /// </summary>
    /// <param name="builder">
    /// The <see cref="IConfigurationBuilder"/> to add to.
    /// </param>
    /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
    public static IConfigurationBuilder AddDotEnvFile(
        this IConfigurationBuilder builder) =>
        AddDotEnvFile(
            builder,
            provider: null,
            path: ".env",
            optional: true,
            reloadOnChange: true);

    /// <summary>
    /// Adds the dotenv configuration provider at 
    /// <paramref name="path"/> to <paramref name="builder"/>.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="IConfigurationBuilder"/> to add to.
    /// </param>
    /// <param name="path">
    /// Path relative to the base path stored in 
    /// <see cref="IConfigurationBuilder.Properties"/> 
    /// of <paramref name="builder"/>.
    /// </param>
    /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
    public static IConfigurationBuilder AddDotEnvFile(
        this IConfigurationBuilder builder,
        string path) =>
        AddDotEnvFile(
            builder,
            provider: null, path: path,
            optional: true,
            reloadOnChange: false);

    /// <summary>
    /// Adds the dotenv configuration provider at 
    /// <paramref name="path"/> to <paramref name="builder"/>.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="IConfigurationBuilder"/> to add to.
    /// </param>
    /// <param name="path">
    /// Path relative to the base path stored in 
    /// <see cref="IConfigurationBuilder.Properties"/> 
    /// of <paramref name="builder"/>.
    /// </param>
    /// <param name="optional">Whether the file is optional.</param>
    /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
    public static IConfigurationBuilder AddDotEnvFile(
        this IConfigurationBuilder builder,
        string path,
        bool optional) =>
        AddDotEnvFile(
            builder,
            provider: null,
            path: path,
            optional: optional,
            reloadOnChange: false);

    /// <summary>
    /// Adds the dotenv configuration provider at 
    /// <paramref name="path"/> to <paramref name="builder"/>.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="IConfigurationBuilder"/> to add to.
    /// </param>
    /// <param name="path">
    /// Path relative to the base path stored in 
    /// <see cref="IConfigurationBuilder.Properties"/> 
    /// of <paramref name="builder"/>.
    /// </param>
    /// <param name="optional">Whether the file is optional.</param>
    /// <param name="reloadOnChange">
    /// Whether the configuration should be reloaded if the file changes.
    /// </param>
    /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
    public static IConfigurationBuilder AddDotEnvFile(
        this IConfigurationBuilder builder,
        string path,
        bool optional,
        bool reloadOnChange) =>
        AddDotEnvFile(
            builder,
            provider: null,
            path: path,
            optional: optional,
            reloadOnChange: reloadOnChange);

    /// <summary>
    /// Adds a .env configuration source to <paramref name="builder"/>.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="IConfigurationBuilder"/> to add to.
    /// </param>
    /// <param name="provider">
    /// The <see cref="IFileProvider"/> to use to access the file.
    /// </param>
    /// <param name="path">
    /// Path relative to the base path stored in 
    /// <see cref="IConfigurationBuilder.Properties"/> 
    /// of <paramref name="builder"/>.
    /// </param>
    /// <param name="optional">Whether the file is optional.</param>
    /// <param name="reloadOnChange">
    /// Whether the configuration should be reloaded if the file changes.
    /// </param>
    /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
    public static IConfigurationBuilder AddDotEnvFile(
        this IConfigurationBuilder builder,
        IFileProvider? provider,
        string path,
        bool optional,
        bool reloadOnChange)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        return builder.AddDotEnvFile(s =>
        {
            s.FileProvider = provider;
            s.Path = path;
            s.Optional = optional;
            s.ReloadOnChange = reloadOnChange;
            s.ResolveFileProvider();
        });
    }

    /// <summary>
    /// Adds a .env configuration source to <paramref name="builder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
    /// <param name="configureSource">Configures the source.</param>
    /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
    public static IConfigurationBuilder AddDotEnvFile(
        this IConfigurationBuilder builder,
        Action<DotEnvConfigurationSource>? configureSource) =>
        builder.Add(configureSource);
}