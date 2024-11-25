using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShopAPP.Repository;
using TechShopAPP.Model;
using TechShopAPP.Util;

namespace TechShopAPP.Services
{
    internal class TechShopService : ITechShopService
    {
        private readonly ITechShopRepository _techShopRepository;

        public TechShopService(ITechShopRepository techShopRepository)
        {
            _techShopRepository = techShopRepository;
        }

        // Customer Methods
        public int CalculateTotalOrders(int customerID)
        {
            return _techShopRepository.CalculateTotalOrders(customerID);
        }

        public Customers GetCustomerDetails(int customerID)
        {
            return _techShopRepository.GetCustomerDetails(customerID);
        }

        public bool AddCustomer(Customers customer)
        {
            return _techShopRepository.AddCustomer(customer);
        }

        public bool UpdateCustomer(Customers customer)
        {
            return _techShopRepository.UpdateCustomer(customer);
        }

        public bool RemoveCustomer(int customerID)
        {
            return _techShopRepository.RemoveCustomer(customerID);
        }

        public Customers GetCustomerById(int customerID)
        {
            return _techShopRepository.GetCustomerById(customerID);
        }

        public List<Customers> SearchCustomers(string keyword)
        {
            return _techShopRepository.SearchCustomers(keyword);
        }

        // Product Methods
        public Products GetProductDetails(int productID)
        {
            return _techShopRepository.GetProductDetails(productID);
        }

        public bool UpdateProduct(Products product)
        {
            return _techShopRepository.UpdateProduct(product);
        }

        public bool IsProductInStock(int productID)
        {
            return _techShopRepository.IsProductInStock(productID);
        }

        public bool AddProduct(Products product)
        {
            return _techShopRepository.AddProduct(product);
        }

        public bool RemoveProduct(int productID)
        {
            return _techShopRepository.RemoveProduct(productID);
        }

        public Products GetProductById(int productID)
        {
            return _techShopRepository.GetProductById(productID);
        }

        public List<Products> SearchProducts(string keyword)
        {
            return _techShopRepository.SearchProducts(keyword);
        }

        // Order Methods
        public decimal CalculateTotalAmount(int orderID)
        {
            return _techShopRepository.CalculateTotalAmount(orderID);
        }

        public Orders GetOrderDetails(int orderID)
        {
            return _techShopRepository.GetOrderDetails(orderID);
        }

        public bool UpdateOrderStatus(int orderID, string status)
        {
            return _techShopRepository.UpdateOrderStatus(orderID, status);
        }

        public bool CancelOrder(int orderID)
        {
            return _techShopRepository.CancelOrder(orderID);
        }

        public bool AddOrder(Orders order)
        {
            return _techShopRepository.AddOrder(order);
        }

        public bool UpdateOrder(Orders order)
        {
            return _techShopRepository.UpdateOrder(order);
        }

        public bool RemoveOrder(int orderID)
        {
            return _techShopRepository.RemoveOrder(orderID);
        }

        public Orders GetOrderById(int orderID)
        {
            return _techShopRepository.GetOrderById(orderID);
        }

        public List<Orders> GetOrdersByCustomerId(int customerID)
        {
            return _techShopRepository.GetOrdersByCustomerId(customerID);
        }

        // OrderDetails Methods
        public decimal CalculateSubtotal(int orderDetailID)
        {
            return _techShopRepository.CalculateSubtotal(orderDetailID);
        }

        public OrderDetails GetOrderDetailInfo(int orderDetailID)
        {
            return _techShopRepository.GetOrderDetailInfo(orderDetailID);
        }

        public bool UpdateQuantity(int orderDetailID, int newQuantity)
        {
            return _techShopRepository.UpdateQuantity(orderDetailID, newQuantity);
        }

        public bool AddDiscount(int orderDetailID, decimal discountPercentage)
        {
            return _techShopRepository.AddDiscount(orderDetailID, discountPercentage);
        }

        // Inventory Methods
        public Products GetProduct(int inventoryID)
        {
            return _techShopRepository.GetProduct(inventoryID);
        }

        public int GetQuantityInStock(int productID)
        {
            return _techShopRepository.GetQuantityInStock(productID);
        }

        public bool AddToInventory(int productID, int quantity)
        {
            return _techShopRepository.AddToInventory(productID, quantity);
        }

        public bool RemoveFromInventory(int productID, int quantity)
        {
            return _techShopRepository.RemoveFromInventory(productID, quantity);
        }

        public bool UpdateStockQuantity(int productID, int newQuantity)
        {
            return _techShopRepository.UpdateStockQuantity(productID, newQuantity);
        }

        public bool IsProductAvailable(int productID, int quantityToCheck)
        {
            return _techShopRepository.IsProductAvailable(productID, quantityToCheck);
        }

        public decimal GetInventoryValue(int inventoryID)
        {
            return _techShopRepository.GetInventoryValue(inventoryID);
        }

        public List<Inventory> ListLowStockProducts(int threshold)
        {
            return _techShopRepository.ListLowStockProducts(threshold);
        }

        public List<Inventory> ListOutOfStockProducts()
        {
            return _techShopRepository.ListOutOfStockProducts();
        }

        public List<Inventory> ListAllInventoryItems()
        {
            return _techShopRepository.ListAllInventoryItems();
        }
    } 
}
