
namespace WarehouseSystem.Structs
{
    using System;

    public struct Dimensions
    {
        private double width;
        private double height;
        public Dimensions(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        #region Propperties
        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        #endregion
        public override string ToString()
        {
            return String.Format("{0}x{1}", this.Width, this.Height);
        }
    }
}
