using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotEnvConfigProvider.Integration.Tests;

public class DotEnvConfigProviderTests
{
    [Fact]
    public void ShouldReadDotEnvConfig()
    {
        var api = new Api();
        
        var config = api.Services.GetRequiredService<IConfiguration>();

        var yoMama = config.GetValue<string>("yomama");
        var cooked = config.GetValue<int>("cooked");
        var youGoofed = config.GetValue<bool>("you_goofed");
        
        Assert.Equal("so fat", yoMama);
        Assert.Equal(420, cooked);
        Assert.True(youGoofed);
    }
}