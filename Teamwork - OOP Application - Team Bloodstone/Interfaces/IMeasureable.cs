

namespace WarehouseSystem.Interfaces
{
    using WarehouseSystem.Structs;

    public interface IMeasureable
    {
        Dimensions Dimensions { get; set; }

        double Weight { get; set; }
    }
}
