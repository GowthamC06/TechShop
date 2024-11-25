using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShopAPP.Model;

namespace TechShopAPP.Model
{
    internal class OrderDetails
    {
        private int _orderDetailID;
        private Orders _order;
        private Products _product;
        private int _quantity;

        public int OrderDetailID
        {
            get { return _orderDetailID; }
            set { _orderDetailID = value; }
        }

        public Orders Order
        {
            get { return _order; }
            set { _order = value; }
        }

        public Products Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value > 0)
                    _quantity = value;
                else
                    throw new ArgumentException("Quantity must be greater than zero.");
            }
        }

        public int OrderID { get; internal set; }

        public decimal CalculateSubtotal()
        {
            return Product.Price * Quantity;
        }

        public string GetOrderDetailInfo()
        {
            return $"Order Detail ID: {OrderDetailID}\nProduct: {Product.ProductName}\nQuantity: {Quantity}\nSubtotal: {CalculateSubtotal():C}\n";
        }

        public void UpdateQuantity(int newQuantity)
        {
            Quantity = newQuantity;
            Console.WriteLine($"Quantity updated to {Quantity} for Order Detail ID {OrderDetailID}.");
        }

        public void AddDiscount(decimal discountPercentage)
        {
            Product.Price -= Product.Price * (discountPercentage / 100);
            Console.WriteLine($"Discount of {discountPercentage}% applied. New price: {Product.Price:C}");
        }

        public override string ToString()
        {
            return $"OrderDetail ID: {OrderDetailID}, Product: {Product.ProductName}, Quantity: {Quantity}, Subtotal: {CalculateSubtotal():C}";
        }
    }
}
