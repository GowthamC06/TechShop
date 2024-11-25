namespace TechShopAPP.Model
{
    internal class Products
    {
        private int _productID;
        private string _productName;
        private string _description;
        private decimal _price;

        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value >= 0)
                    _price = value;
                else
                    throw new ArgumentException("Price cannot be negative.");
            }
        }

        public string GetProductDetails()
        {
            return $"Product ID: {ProductID}\nName: {ProductName}\nDescription: {Description}\nPrice: {Price:C}\n";
        }

        public void UpdateProductInfo(string description, decimal price)
        {
            Description = description;
            Price = price;

            Console.WriteLine("Product information updated successfully!");
        }

        public bool IsProductInStock(int stockQuantity)
        {
            return stockQuantity > 0;
        }

        public override string ToString()
        {
            return $"Product ID: {ProductID}, Name: {ProductName}, Price: {Price:C}";
        }
    }
}