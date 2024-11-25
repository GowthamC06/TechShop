using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopAPP.Exceptions
{
    internal class Exceptions
    {
    // Base Exception Class for all TechShop-related exceptions (optional)
    public class TechShopException : Exception
        {
            public TechShopException(string message) : base(message)
            {
            }
        }

        // InvalidDataException: Thrown when the input data is invalid
        public class InvalidDataException : TechShopException
        {
            public InvalidDataException(string message) : base(message)
            {
            }
        }

        // InsufficientStockException: Thrown when there is not enough stock for an order
        public class InsufficientStockException : TechShopException
        {
            public InsufficientStockException(string message) : base(message)
            {
            }
        }

        // IncompleteOrderException: Thrown when an order is incomplete or missing important details
        public class IncompleteOrderException : TechShopException
        {
            public IncompleteOrderException(string message) : base(message)
            {
            }
        }
    }

}