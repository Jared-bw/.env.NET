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
            .AddDotEnvFile(path: "test.env", optional: false)
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

    [Fact]
    public void ShouldNotReadCommentsFromDotEnvConfig()
    {
         var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddDotEnvFile(path: "comments.test.env", optional: false)
            .Build();

         var commentedOutConfig = config.GetValue<string>("#commentedOutConfig");
         var alsoCommentedOutConfig = config.GetValue<string>("# alsoCommentedOut");
         var commentedOutWithWhiteSpace = config.GetValue<string>(" #commentedOutWithWhiteSpace");
         
         var configWithComment = config.GetValue<string>("configWithComment");
         var configWithCommentAndWhiteSpace = config.GetValue<string>("configWithCommentAndWhiteSpace");
         
         Assert.Null(commentedOutConfig);
         Assert.Null(alsoCommentedOutConfig);
         Assert.Null(commentedOutWithWhiteSpace);
         
         Assert.Equal("big comment", configWithComment);
         Assert.Equal("bigger comment ", configWithCommentAndWhiteSpace);
    }

    public enum Foo
    {
        Baz,
        Bar,
    }
}