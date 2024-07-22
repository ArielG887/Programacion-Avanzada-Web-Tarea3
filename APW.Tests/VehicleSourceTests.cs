using APW.Architecture;
using APW.DataSource;
using APW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APW.Tests;

public class VehicleSourceFixture : IDisposable
{
    public IVehicleSource SourceProvider { get; private set; }

    public VehicleSourceFixture()
    {
        SourceProvider = new CarSource();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

public class VehicleSourceTests : VehicleSourceFixture
{
    private readonly IVehicleSource _sourceProvider;

    public VehicleSourceTests()
    {
        _sourceProvider = SourceProvider;
    }

    [Fact]
    public void Test1()
    {
        var cars = new List<Car>(_sourceProvider.Cars);
        var first = cars.First();
        var results = _sourceProvider.DeleteCar(first.Id.ToString());
        Assert.NotNull(results);
        Assert.True(results.Count() == 19);
        Assert.DoesNotContain(first, results);
    }
}
