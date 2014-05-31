
namespace WarehouseSystem.StoreObjects
{
    using System;
    using WarehouseSystem.Interfaces;
    using WarehouseSystem.Enumerations;

    public class SanitaryObject : StoreObject, IColorable
    {
        private Color color;

        public SanitaryObject()
        {
        }

        public SanitaryObject(string catalogueNumber, string manufacturer, string model, string description, int quantity, Branch category, decimal price, Color color)
            : base(catalogueNumber, manufacturer, model, description, quantity, category, price)
        {
            this.color = color;            
        }
    
        public Color Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }
    }
}
