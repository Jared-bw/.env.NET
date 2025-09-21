# Features

Loads environment variables from a .env file.
Integrates with Microsoft.Extensions.Configuration so .env values can be read like other config sources.
Lightweight, minimal dependencies.

## Contributions welcome

The parser is pretty dumb. You could immediately understand what it does at a glance.

# Why use it
If you’re building a .NET app and want to:

- manage configuration via .env files (common in many ecosystems)
- avoid hardcoding sensitive values or spanning environment setup differences
- support local development setups easily

...then .Env.NET helps you do that cleanly within the .NET configuration framework.

## Basic Usage

### Simple .env File Loading

Load a `.env` file from the application root with default settings (optional, reload on change):

```csharp
var configuration = new ConfigurationBuilder()
    .AddDotEnvFile()
    .Build();
```

This will look for a `.env` file in the application's base directory with these defaults:
- File is optional (won't throw if missing)
- Automatically reloads when file changes

### Load Specific .env File

Load a .env file from a specific path:

```csharp
var configuration = new ConfigurationBuilder()
    .AddDotEnvFile("config/app.env")
    .Build();
```

### Required .env File

Make the .env file required (throws exception if missing):

```csharp
var configuration = new ConfigurationBuilder()
    .AddDotEnvFile(".env", optional: false)
    .Build();
```

### Disable Reload on Change

Load .env file without automatic reloading:

```csharp
var configuration = new ConfigurationBuilder()
    .AddDotEnvFile(".env", optional: true, reloadOnChange: false)
    .Build();
```

## Complete Examples

### ASP.NET Core Web Application

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add .env file support
builder.Configuration.AddDotEnvFile();

// Add other configuration sources
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

var app = builder.Build();
```

### Console Application

```csharp
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DotEnvConfigProvider;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddDotEnvFile(".env", optional: true, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        // Register your services here
    })
    .Build();


```

### Multiple Environment Files

```csharp
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

var configuration = new ConfigurationBuilder()
    .AddDotEnvFile(".env", optional: true)  // Base .env file
    .AddDotEnvFile($".env.{environment}", optional: true)  // Environment-specific
    .AddDotEnvFile(".env.local", optional: true)  // Local overrides
    .Build();
```
