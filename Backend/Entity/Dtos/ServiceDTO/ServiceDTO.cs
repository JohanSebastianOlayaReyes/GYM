using Entity.Dtos.Base;

namespace Gym;

public class ServiceDTO : BaseDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsSubscription { get; set; }
    public string Description { get; set; }
}
