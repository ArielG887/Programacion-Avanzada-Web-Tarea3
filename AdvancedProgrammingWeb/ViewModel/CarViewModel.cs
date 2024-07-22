using APW.DataSource;
using APW.Models;

namespace AdvancedProgrammingWeb.ViewModel;

public class CarViewModel
{
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public DateTime RegisteredTime { get; set; }
    public string? Id { get;set; }

    public static Car FromCarViewModelToCar(CarViewModel carViewModel)
    {
        return new Car
        {
            Id = Guid.Parse(carViewModel.Id),
            Brand = carViewModel.Brand,
            Model = carViewModel.Model,
        };
    }

    public static CarViewModel FromCarToCarViewModel(Car car)
    {
        return new CarViewModel
        {
            Id = car.Guid,
            Brand = car.Brand,
            Model = car.Model,
            RegisteredTime = DateTime.Now
        };
    }
}
