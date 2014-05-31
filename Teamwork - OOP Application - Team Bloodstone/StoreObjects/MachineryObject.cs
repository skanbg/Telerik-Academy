
namespace WarehouseSystem.StoreObjects
{
    using System;
    using WarehouseSystem.Interfaces;
    using WarehouseSystem.Enumerations;
    using WarehouseSystem.Structs;

    public class MachineryObject : StoreObject, IMeasureable
    {
        private Dimensions dimensions;
        private double weight;

        public MachineryObject()
        {
        }

        public MachineryObject(string catalogueNumber, string manufacturer, string model, string description, int quantity, Branch category, decimal price, Dimensions dimensions, double weight)
            : base(catalogueNumber, manufacturer, model, description, quantity,category, price)
        {
            this.dimensions = dimensions;
            this.weight = weight;
        }

        public Dimensions Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }
    }
}
