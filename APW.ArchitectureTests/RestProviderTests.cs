using APW.Architecture;

namespace APW.ArchitectureTests;

[TestClass()]
public class RestProviderTests(IRestProvider restProvider)
{
    private readonly IRestProvider _restProvider = restProvider;

    [TestMethod()]
    public void GetAsyncTest()
    {
        var result = _restProvider.GetAsync("https://api.restful-api.dev/objects");
        Assert.IsNotNull(result);
    }
}
