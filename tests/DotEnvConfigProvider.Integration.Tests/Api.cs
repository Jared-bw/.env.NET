using DotEnvConfigProvider.Api;
using Microsoft.AspNetCore.Mvc.Testing;

namespace DotEnvConfigProvider.Integration.Tests;

public class Api : WebApplicationFactory<IApiMarker> { }