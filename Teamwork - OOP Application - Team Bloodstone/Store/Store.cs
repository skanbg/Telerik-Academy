
namespace WarehouseSystem.Store
{
    using System;
    using System.Collections.Generic;
    using WarehouseSystem.Enumerations;
    using WarehouseSystem.StoreObjects;

    public abstract class Store
    {
        protected List<StoreObject> productsList = new List<StoreObject>();
        protected List<string> productCategories = new List<string>();

        public Store()
        {
            LoadStore();
        }

        public void AddProduct(StoreObject product)
        {
            this.productsList.Add(product);
        }

        public List<StoreObject> GetAllProducts()
        {
            return this.productsList;
        }

        public List<string> GetCategories()
        {
            var result = new List<string>();
            result.Add("Choose...");
            foreach (var item in Enum.GetValues(typeof(Branch)))
            {
                result.Add(item.ToString());
            }

            return result;
        }

        public abstract void LoadStore();

        public abstract void SaveStore();
    }
}
