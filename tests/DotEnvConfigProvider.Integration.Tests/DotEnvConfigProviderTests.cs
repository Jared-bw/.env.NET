using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotEnvConfigProvider.Integration.Tests;

public class DotEnvConfigProviderTests
{
    [Fact]
    public void ShouldReadDotEnvConfig()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddDotEnvFile()
            .Build();

        var foo = config.GetValue<Foo>("bigFoo");
        var yoMama = config.GetValue<string>("yomama");
        var cooked = config.GetValue<int>("cooked");
        var youGoofed = config.GetValue<bool>("you_goofed");
        
        Assert.Equal(Foo.Bar, foo);
        Assert.Equal("so fat", yoMama);
        Assert.Equal(420, cooked);
        Assert.True(youGoofed);
    }

    public enum Foo
    {
        Baz,
        Bar,
    }
}