using TechShopAPP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShopAPP.Main;
using TechShopAPP.Services;
using TechShopAPP.Repository;
using TechShopAPP.Util;

namespace TechShopAPP.Repository
{
    internal interface ITechShopRepository
    {
        //List<Customers> GetAllCustomers();

        //Customers
        int CalculateTotalOrders(int customerID);
        Customers GetCustomerDetails(int customerID);
        bool AddCustomer(Customers customer);
        bool UpdateCustomer(Customers customer);
        bool RemoveCustomer(int customerID);
        Customers GetCustomerById(int customerID);
        List<Customers> SearchCustomers(string keyword);

        // Products Methods
        Products GetProductDetails(int productID);
        bool UpdateProduct(Products product); 
        bool IsProductInStock(int productID); 
        bool AddProduct(Products product); 
        bool RemoveProduct(int productID); 
        Products GetProductById(int productID); 
        List<Products> SearchProducts(string keyword); 

        // Orders Methods
        decimal CalculateTotalAmount(int orderID); 
        Orders GetOrderDetails(int orderID);
        bool UpdateOrderStatus(int orderID, string status);
        bool CancelOrder(int orderID); 
        bool AddOrder(Orders order); 
        bool UpdateOrder(Orders order); 
        bool RemoveOrder(int orderID);
        Orders GetOrderById(int orderID); 
        List<Orders> GetOrdersByCustomerId(int customerID); 

        // OrderDetails Methods
        decimal CalculateSubtotal(int orderDetailID);
        OrderDetails GetOrderDetailInfo(int orderDetailID);
        bool UpdateQuantity(int orderDetailID, int newQuantity); 
        bool AddDiscount(int orderDetailID, decimal discountPercentage); 

        // Inventory Methods
        Products GetProduct(int inventoryID); 
        int GetQuantityInStock(int productID); 
        bool AddToInventory(int productID, int quantity); 
        bool RemoveFromInventory(int productID, int quantity);
        bool UpdateStockQuantity(int productID, int newQuantity); 
        bool IsProductAvailable(int productID, int quantityToCheck); 
        decimal GetInventoryValue(int inventoryID);
        List<Inventory> ListLowStockProducts(int threshold); 
        List<Inventory> ListOutOfStockProducts(); 
        List<Inventory> ListAllInventoryItems(); 
        bool IsProductAvailable(object productID, object quantity);

    }
}
