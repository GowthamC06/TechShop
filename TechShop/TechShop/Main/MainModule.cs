using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShopAPP.Repository;
using TechShopAPP.Model; 
using TechShopAPP.Services;
using TechShopAPP.Util;


namespace TechShopAPP.Main
{
    internal class MainModule
    {
        public void Module()
        {
            ITechShopRepository service = new TechShopRepository();
            //List<Customers> allcustomers = service.GetAllCustomers();

            //foreach (Customers cus in allcustomers)
            //{
            //    Console.WriteLine(cus);
            //}
            // Customer Methods
            ITechShopRepository techShopRepository = new TechShopRepository();
            ITechShopService techShopService = new TechShopService(techShopRepository);

            bool continueRunning = true;

            while (continueRunning)
            {
                try
                {
                    Console.WriteLine("\n---- TechShop Management ----");
                    Console.WriteLine("1. Add New Customer");
                    Console.WriteLine("2. Update Customer");
                    Console.WriteLine("3. Remove Customer");
                    Console.WriteLine("4. View Customer By ID");
                    Console.WriteLine("5. Search Customers");
                    Console.WriteLine("6. Add New Product");
                    Console.WriteLine("7. Update Product");
                    Console.WriteLine("8. Remove Product");
                    Console.WriteLine("9. View Product By ID");
                    Console.WriteLine("10. Search Products");
                    Console.WriteLine("11. Create Order");
                    Console.WriteLine("12. Update Order");
                    Console.WriteLine("13. Remove Order");
                    Console.WriteLine("14. View Order By ID");
                    Console.WriteLine("15. List All Inventory");
                    Console.WriteLine("16. Exit");
                    Console.Write("Choose an option: ");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    { 
                       
                        case 1:
                            { 
                            Console.WriteLine("Enter Customer Details:");
                            Customers newCustomer = new Customers();

                            Console.Write("First Name: ");
                            newCustomer.FirstName = Console.ReadLine();

                            Console.Write("Last Name: ");
                            newCustomer.LastName = Console.ReadLine();

                            Console.Write("Email: ");
                            newCustomer.Email = Console.ReadLine();

                            Console.Write("Phone: ");
                            newCustomer.Phone = Console.ReadLine();

                            Console.Write("Address: ");
                            newCustomer.Address = Console.ReadLine();

                            try
                            {
                                if (techShopService.AddCustomer(newCustomer))
                                    Console.WriteLine("Customer added successfully.");
                                else
                                    Console.WriteLine("Failed to add customer.");
                            }
                            catch (InvalidDataException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                             }
                        case 2:
                            { 
                            Console.Write("Enter Customer ID to update: ");
                            int updateCustomerID = int.Parse(Console.ReadLine());

                            try
                            {
                                Customers existingCustomer = techShopService.GetCustomerById(updateCustomerID);

                                Console.Write("New First Name (leave blank to keep current): ");
                                string newFirstName = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(newFirstName)) existingCustomer.FirstName = newFirstName;

                                Console.Write("New Last Name (leave blank to keep current): ");
                                string newLastName = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(newLastName)) existingCustomer.LastName = newLastName;

                                Console.Write("New Email (leave blank to keep current): ");
                                string newEmail = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(newEmail)) existingCustomer.Email = newEmail;

                                if (techShopService.UpdateCustomer(existingCustomer))
                                    Console.WriteLine("Customer updated successfully.");
                                else
                                    Console.WriteLine("Failed to update customer.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                             }
                        case 3:
                            { 
                            Console.Write("Enter Customer ID to remove: ");
                            int removeCustomerID = int.Parse(Console.ReadLine());

                            try
                            {
                                if (techShopService.RemoveCustomer(removeCustomerID))
                                    Console.WriteLine("Customer removed successfully.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                            }
                        case 4:
                            { 
                            Console.Write("Enter Customer ID: ");
                            int viewCustomerID = int.Parse(Console.ReadLine());

                            try
                            {
                                Customers customer = techShopService.GetCustomerById(viewCustomerID);
                                Console.WriteLine($"First Name: {customer.FirstName}");
                                Console.WriteLine($"Last Name: {customer.LastName}");
                                Console.WriteLine($"Email: {customer.Email}");
                                Console.WriteLine($"Phone: {customer.Phone}");
                                Console.WriteLine($"Address: {customer.Address}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                               } 
                        case 5:
                            { 
                            Console.Write("Enter keyword to search: ");
                            string keyword = Console.ReadLine();

                            var customers = techShopService.SearchCustomers(keyword);
                            if (customers.Count > 0)
                            {
                                Console.WriteLine("Search Results:");
                                foreach (var customer in customers)
                                {
                                    Console.WriteLine($"ID: {customer.CustomerID}, Name: {customer.FirstName} {customer.LastName}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No customers found.");
                            }
                            break;

                            }
                        case 6:
                            { 
                            Console.WriteLine("Enter Product Details:");
                            Products newProduct = new Products();

                            Console.Write("Product Name: ");
                            newProduct.ProductName = Console.ReadLine();

                            Console.Write("Description: ");
                            newProduct.Description = Console.ReadLine();

                            Console.Write("Price: ");
                            newProduct.Price = decimal.Parse(Console.ReadLine());

                            try
                            {
                                if (techShopService.AddProduct(newProduct))
                                    Console.WriteLine("Product added successfully.");
                                else
                                    Console.WriteLine("Failed to add product.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                              }
                        case 7:
                            { 
                            Console.Write("Enter Product ID to update: ");
                            int updateProductID = int.Parse(Console.ReadLine());

                            try
                            {
                                Products existingProduct = techShopService.GetProductById(updateProductID);

                                Console.Write("New Product Name (leave blank to keep current): ");
                                string newProductName = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(newProductName)) existingProduct.ProductName = newProductName;

                                Console.Write("New Description (leave blank to keep current): ");
                                string newDescription = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(newDescription)) existingProduct.Description = newDescription;

                                Console.Write("New Price (leave blank to keep current): ");
                                string newPriceStr = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(newPriceStr)) existingProduct.Price = decimal.Parse(newPriceStr);

                                if (techShopService.UpdateProduct(existingProduct))
                                    Console.WriteLine("Product updated successfully.");
                                else
                                    Console.WriteLine("Failed to update product.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                              }
                        case 8:
                            { 
                            Console.Write("Enter Product ID to remove: ");
                            int removeProductID = int.Parse(Console.ReadLine());

                            try
                            {
                                if (techShopService.RemoveProduct(removeProductID))
                                    Console.WriteLine("Product removed successfully.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                             }
                        case 9:
                            { 
                            Console.Write("Enter Product ID: ");
                            int viewProductID = int.Parse(Console.ReadLine());

                            try
                            {
                                Products product = techShopService.GetProductById(viewProductID);
                                Console.WriteLine($"Product Name: {product.ProductName}");
                                Console.WriteLine($"Description: {product.Description}");
                                Console.WriteLine($"Price: {product.Price:C}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                            }
                        case 10:
                            { 
                            Console.Write("Enter keyword to search: ");
                            string productKeyword = Console.ReadLine();

                            var products = techShopService.SearchProducts(productKeyword);
                            if (products.Count > 0)
                            {
                                Console.WriteLine("Search Results:");
                                foreach (var product in products)
                                {
                                    Console.WriteLine($"ID: {product.ProductID}, Name: {product.ProductName}, Price: {product.Price:C}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No products found.");
                            }
                            break;

                             }
                        case 11:
                            { 
                            Console.WriteLine("Enter Order Details:");
                            Orders newOrder = new Orders();

                            Console.Write("Customer ID: ");
                            newOrder.Customer = techShopService.GetCustomerById(int.Parse(Console.ReadLine()));

                            Console.Write("Order Date (YYYY-MM-DD): ");
                            newOrder.OrderDate = DateTime.Parse(Console.ReadLine());

                            newOrder.TotalAmount = 0;  // Assuming this will be calculated based on order details later.

                            if (techShopService.AddOrder(newOrder))
                                Console.WriteLine("Order created successfully.");
                            else
                                Console.WriteLine("Failed to create order.");
                            break;
                             }

                        case 12:
                            { 
                            Console.Write("Enter Order ID: ");
                            int viewOrderID = int.Parse(Console.ReadLine());

                            try
                            {
                                Orders order = techShopService.GetOrderById(viewOrderID);
                                Console.WriteLine($"Order ID: {order.OrderID}");
                                Console.WriteLine($"Customer: {order.Customer.FirstName} {order.Customer.LastName}");
                                Console.WriteLine($"Order Date: {order.OrderDate}");
                                Console.WriteLine($"Total Amount: {order.TotalAmount:C}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                               }
                        case 13:
                            { 
                            Console.Write("Enter Customer ID to list orders: ");
                            int customerIDForOrders = int.Parse(Console.ReadLine());

                            try
                            {
                                var orders = techShopService.GetOrdersByCustomerId(customerIDForOrders);
                                if (orders.Count > 0)
                                {
                                    Console.WriteLine("Orders:");
                                    foreach (var order in orders)
                                    {
                                        Console.WriteLine($"Order ID: {order.OrderID}, Date: {order.OrderDate}, Total: {order.TotalAmount:C}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No orders found for this customer.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                            }

                        case 14:
                            { 
                            var inventoryItems = techShopService.ListAllInventoryItems();
                            Console.WriteLine("Inventory List:");
                            foreach (var inventory in inventoryItems)
                            {
                                Console.WriteLine($"Product ID: {inventory.Product.ProductID}, Product Name: {inventory.Product.ProductName}, Quantity: {inventory.QuantityInStock}");
                            }
                            break;
                            }

                        case 15:
                            { 
                            Console.Write("Enter stock threshold: ");
                            int threshold = int.Parse(Console.ReadLine());

                            var lowStockProducts = techShopService.ListLowStockProducts(threshold);
                            if (lowStockProducts.Count > 0)
                            {
                                Console.WriteLine("Low Stock Products:");
                                foreach (var item in lowStockProducts)
                                {
                                    Console.WriteLine($"Product: {item.Product.ProductName}, Quantity: {item.QuantityInStock}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No products below the threshold.");
                            }
                            break;

                                }
                        case 16:
                            {
                                continueRunning = false;
                                Console.WriteLine("Exiting the system.");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
        }
    }
}
