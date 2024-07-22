using System;
using Xunit;
using APW.Architecture;
using Moq;
namespace APW.Tests;

public class RestProviderTests()
{
    private readonly RestProvider _restProvider = new RestProvider();

    [Fact]
    public void Test1()
    {
        //var result = _restProvider.GetAsync("https://api.restful-api.dev/objects");
        //Assert.NotNull(result);
    }
}