
namespace WarehouseSystem.StoreObjects
{
    using System;
    using WarehouseSystem.Interfaces;
    using WarehouseSystem.Enumerations;

    public class ElectronicObject : StoreObject, IDigital, IColorable
    {
        private double display;
        private int capacity;
        private Color color;


        public ElectronicObject()
        {

        }

        public ElectronicObject(string catalogueNumber, string manufacturer, string model, string description, int quantity, Branch category, decimal price, Color color, double display, int capacity)
            : base(catalogueNumber, manufacturer, model, description, quantity, category, price)
        {
            this.display = display;
            this.capacity = capacity;
            this.color = color;
        }

        #region Properties
        public double Display
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                this.capacity = value;
            }
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
        #endregion
    }
}
