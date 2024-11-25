using System;

namespace TechShopAPP.Model
{
    internal class Inventory
    {
        private int _inventoryID;
        private Products _product; // Composition: Links Product
        private int _quantityInStock;
        private DateTime _lastStockUpdate;

        public int InventoryID
        {
            get { return _inventoryID; }
            set { _inventoryID = value; }
        }

        public Products Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public int QuantityInStock
        {
            get { return _quantityInStock; }
            set
            {
                if (value >= 0)
                    _quantityInStock = value;
                else
                    throw new ArgumentException("Stock quantity cannot be negative.");
            }
        }

        public DateTime LastStockUpdate
        {
            get { return _lastStockUpdate; }
            set { _lastStockUpdate = value; }
        }

        // Method to get the associated product
        public Products GetProduct()
        {
            return Product; // Returning the Product object for further usage
        }

        // Method to get current stock quantity
        public int GetQuantityInStock()
        {
            return QuantityInStock;
        }

        // Add stock to inventory
        public void AddToInventory(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity to add must be greater than zero.");

            QuantityInStock += quantity;
            LastStockUpdate = DateTime.Now;

            Console.WriteLine($"{quantity} units added to inventory. Total stock for {Product.ProductName}: {QuantityInStock}");
        }

        // Remove stock from inventory
        public void RemoveFromInventory(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity to remove must be greater than zero.");

            if (quantity > QuantityInStock)
                throw new InvalidOperationException($"Insufficient stock. Only {QuantityInStock} units available.");

            QuantityInStock -= quantity;
            LastStockUpdate = DateTime.Now;

            Console.WriteLine($"{quantity} units removed from inventory. Remaining stock for {Product.ProductName}: {QuantityInStock}");
        }

        // Update stock to a specific value
        public void UpdateStockQuantity(int newQuantity)
        {
            if (newQuantity < 0)
                throw new ArgumentException("New stock quantity cannot be negative.");

            QuantityInStock = newQuantity;
            LastStockUpdate = DateTime.Now;

            Console.WriteLine($"Stock updated. New quantity for {Product.ProductName}: {QuantityInStock}");
        }

        // Check if the product is available in the required quantity
        public bool IsProductAvailable(int quantityToCheck)
        {
            return QuantityInStock >= quantityToCheck;
        }

        // Calculate total inventory value for this product
        public decimal GetInventoryValue()
        {
            return Product.Price * QuantityInStock;
        }

        // Check if product stock is below a given threshold
        public bool IsLowStock(int threshold)
        {
            return QuantityInStock < threshold;
        }

        // List products with stock below a given threshold
        public void ListLowStockProducts(int threshold)
        {
            if (IsLowStock(threshold))
            {
                Console.WriteLine($"Low stock alert for {Product.ProductName}: {QuantityInStock} units (threshold: {threshold}).");
            }
        }

        // Check if product is out of stock
        public bool IsOutOfStock()
        {
            return QuantityInStock == 0;
        }

        // List products that are out of stock
        public void ListOutOfStockProducts()
        {
            if (IsOutOfStock())
            {
                Console.WriteLine($"Out of stock: {Product.ProductName}");
            }
        }

        // List all inventory details for a product
        public void ListAllProducts()
        {
            Console.WriteLine($"Inventory ID: {InventoryID}\n" +
                              $"Product: {Product.ProductName}\n" +
                              $"Quantity in Stock: {QuantityInStock}\n" +
                              $"Last Stock Update: {LastStockUpdate}\n");
        }

        public override string ToString()
        {
            return $"Inventory ID: {InventoryID}, Product: {Product.ProductName}, Stock: {QuantityInStock}, Last Updated: {LastStockUpdate}";
        }
    }
}
