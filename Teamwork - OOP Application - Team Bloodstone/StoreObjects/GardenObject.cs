
namespace WarehouseSystem.StoreObjects
{
    using System;
    using WarehouseSystem.Interfaces;
    using WarehouseSystem.Enumerations;
    using WarehouseSystem.Structs;

    public class GardenObject : StoreObject, IMeasureable
    {
        private Dimensions dimensions;
        private double weight;
        public GardenObject()
        {

        }
        public GardenObject(string catalogueNumber, string manufacturer, string model, string description, int quantity, Branch category, decimal price, Dimensions dimensions, double weight)
            : base(catalogueNumber, manufacturer,model, description, quantity, category, price)
        {
            this.dimensions = dimensions;
            this.weight = weight;
        }

        #region Properties
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

        #endregion
    }
}
