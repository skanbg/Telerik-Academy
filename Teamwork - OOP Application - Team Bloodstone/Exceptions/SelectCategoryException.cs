
namespace WarehouseSystem.Exceptions
{
    using System;   

    public class SelectCategoryException : ApplicationException
    {
        private const string message = "The input data includes a category dropdown, which has not been checked.";

        
        public SelectCategoryException() : base(message)
        {            
        }
    }
}
