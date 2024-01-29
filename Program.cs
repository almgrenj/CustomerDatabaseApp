using CustomerDatabaseApp.Services;
using CustomerDatabaseApp.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using CustomerDatabaseApp.Repositories.Interfaces;

class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        var serviceProvider = services.BuildServiceProvider();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nVälkommen till Kunddatabasen!");
            Console.WriteLine("1. Hantera Kunder");
            Console.WriteLine("2. Hantera Ordrar");
            Console.WriteLine("3. Hantera Produkter");
            Console.WriteLine("4. Hantera Kategorier");
            Console.WriteLine("5. Hantera Leverantörer");
            Console.WriteLine("6. Hantera Orderartiklar");
            Console.WriteLine("7. Avsluta");
            Console.Write("Välj ett alternativ: ");

            switch (Console.ReadLine())
            {
                case "1":
                    HandleCustomers(serviceProvider);
                    break;
                case "2":
                    HandleOrders(serviceProvider);
                    break;
                case "3":
                    HandleProducts(serviceProvider);
                    break;
                case "4":
                    HandleCategories(serviceProvider);
                    break;
                case "5":
                    HandleSuppliers(serviceProvider);
                    break;
                case "6":
                    HandleOrderItems(serviceProvider);
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }
    }
    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<CustomerDbContext>(options =>
            options.UseSqlServer(@"Server=192.168.50.168,1433;Database=testingdb;User Id=sa;Password=NewP@ssw0rd;Encrypt=False;TrustServerCertificate=True;"));

      
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();

      
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IOrderItemService, OrderItemService>();
        services.AddScoped<ISupplierService, SupplierService>();
    }

    private static void HandleCustomers(IServiceProvider serviceProvider)
    {
        var customerService = serviceProvider.GetService<ICustomerService>();

        while (true)
        {
            Console.WriteLine("\nHantering av kunder:");
            Console.WriteLine("1. Lägg till kund");
            Console.WriteLine("2. Visa alla kunder");
            Console.WriteLine("3. Uppdatera kund");
            Console.WriteLine("4. Ta bort kund");
            Console.WriteLine("5. Tillbaka till huvudmenyn");
            Console.Write("Välj ett alternativ: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddCustomer(customerService);
                    break;
                case "2":
                    ShowAllCustomers(customerService);
                    break;
                case "3":
                    UpdateCustomer(customerService);
                    break;
                case "4":
                    DeleteCustomer(customerService);
                    break;
                case "5":
                    return; // Gå tillbaka till Huvudmenyn
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }
    }

    private static void AddCustomer(ICustomerService customerService)
    {
        try
        {
            Console.Write("Ange kundens namn: ");
            var name = Console.ReadLine();
            Console.Write("Ange kundens email: ");
            var email = Console.ReadLine();
            Console.Write("Ange kundens adress: ");
            var address = Console.ReadLine();
            Console.Write("Ange kundens telefonnummer: ");
            var phone = Console.ReadLine();

            var newCustomer = new Customer
            {
                Name = name,
                Email = email,
                Address = address,
                Phone = phone
            };
            customerService.AddCustomer(newCustomer);
            Console.WriteLine("Kund tillagd!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ett fel inträffade: {ex.Message}");
        }
    }


    private static void ShowAllCustomers(ICustomerService customerService)
    {
        var customers = customerService.GetAllCustomers();
        foreach (var customer in customers)
        {
            Console.WriteLine($"ID: {customer.CustomerId}, Namn: {customer.Name}, Email: {customer.Email}, Adress: {customer.Address}, Telefon: {customer.Phone}");
        }


    }

    private static void UpdateCustomer(ICustomerService customerService)
    {
        Console.Write("Ange ID för kunden att uppdatera: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Ogiltigt ID-format.");
            return;
        }

        var customer = customerService.GetCustomer(id);
        if (customer == null)
        {
            Console.WriteLine($"Ingen kund hittades med ID {id}");
            return;
        }

        Console.Write("Ange nytt namn (lämna tomt för ingen ändring): ");
        var name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name))
        {
            customer.Name = name;
        }

        Console.Write("Ange ny adress (lämna tomt för ingen ändring): ");
        var address = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(address))
        {
            customer.Address = address;
        }

        Console.Write("Ange nytt telefonnummer (lämna tomt för ingen ändring): ");
        var phone = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(phone))
        {
            customer.Phone = phone;
        }

        Console.Write("Ange ny e-post (lämna tomt för ingen ändring): ");
        var email = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(email))
        {
            customer.Email = email;
        }

        try
        {
            customerService.UpdateCustomer(customer);
            Console.WriteLine("Kund uppdaterad!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ett fel inträffade vid uppdatering: {ex.Message}");
        }
    }

    private static void DeleteCustomer(ICustomerService customerService)
    {
        Console.Write("Ange ID för kunden att ta bort: ");
        var id = int.Parse(Console.ReadLine());
        customerService.DeleteCustomer(id);
        Console.WriteLine("Kund borttagen!");
    }

    private static void HandleOrders(IServiceProvider serviceProvider)
    {
        var orderService = serviceProvider.GetService<IOrderService>();
        var customerService = serviceProvider.GetService<ICustomerService>();

        while (true) 
        {
            Console.WriteLine("\nHantering av ordrar:");
            Console.WriteLine("1. Lägg till order");
            Console.WriteLine("2. Visa alla ordrar");
            Console.WriteLine("3. Uppdatera order");
            Console.WriteLine("4. Ta bort order");
            Console.WriteLine("5. Tillbaka till huvudmenyn");
            Console.Write("Välj ett alternativ: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddOrder(orderService, customerService);
                    break;
                case "2":
                    ShowAllOrders(orderService);
                    break;
                case "3":
                    UpdateOrder(orderService);
                    break;
                case "4":
                    DeleteOrder(orderService);
                    break;
                case "5":
                    return; // Gå tillbaka till Huvudmenyn
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }
    }

    private static void AddOrder(IOrderService orderService, ICustomerService customerService)
    {
        Console.WriteLine("Tillgängliga kunder:");
        var customers = customerService.GetAllCustomers();
        foreach (var customer in customers)
        {
            Console.WriteLine($"ID: {customer.CustomerId}, Namn: {customer.Name}");
        }

        Console.Write("Ange kundens ID för order: ");
        int customerId;
        if (!int.TryParse(Console.ReadLine(), out customerId))
        {
            Console.WriteLine("Ogiltigt ID. Ange ett numeriskt värde.");
            return;
        }

        var customerExists = customerService.GetCustomer(customerId) != null;
        if (!customerExists)
        {
            Console.WriteLine("Ingen kund med angivet ID. Försök igen.");
            return;
        }

        Console.Write("Ange totalbelopp för ordern: ");
        decimal totalAmount;
        if (!decimal.TryParse(Console.ReadLine(), out totalAmount))
        {
            Console.WriteLine("Ogiltigt belopp.");
            return;
        }

        Console.Write("Ange status för ordern: ");
        var status = Console.ReadLine();

        Console.Write("Ange leveransadress för ordern: ");
        var shippingAddress = Console.ReadLine();

        var order = new Order
        {
            CustomerId = customerId,
            OrderDate = DateTime.Now,
            TotalAmount = totalAmount,
            Status = status,
            ShippingAddress = shippingAddress
        };

        orderService.AddOrder(order);
        Console.WriteLine("Order tillagd!");
    }

    private static void ShowAllOrders(IOrderService orderService)
    {
        var orders = orderService.GetAllOrders();

        foreach (var order in orders)
        {
            Console.WriteLine($"Order ID: {order.OrderId}, Kund ID: {order.CustomerId}, Orderdatum: {order.OrderDate}, Totalbelopp: {order.TotalAmount}, Status: {order.Status}, Leveransadress: {order.ShippingAddress}");
        }
    }

    private static void UpdateOrder(IOrderService orderService)
    {
        Console.Write("Ange ID för den order att uppdatera: ");
        if (!int.TryParse(Console.ReadLine(), out int orderId))
        {
            Console.WriteLine("Ogiltigt ID-format.");
            return;
        }

        var order = orderService.GetOrder(orderId);
        if (order == null)
        {
            Console.WriteLine($"Ingen order hittades med ID {orderId}");
            return;
        }

        Console.Write("Ange nytt totalbelopp (lämna tomt för ingen ändring): ");
        var totalAmountInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(totalAmountInput) && decimal.TryParse(totalAmountInput, out var totalAmount))
        {
            order.TotalAmount = totalAmount;
        }

        Console.Write("Ange ny status (lämna tomt för ingen ändring): ");
        var status = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(status))
        {
            order.Status = status;
        }

        Console.Write("Ange ny leveransadress (lämna tomt för ingen ändring): ");
        var shippingAddress = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(shippingAddress))
        {
            order.ShippingAddress = shippingAddress;
        }

        orderService.UpdateOrder(order);
        Console.WriteLine("Order uppdaterad!");
    }


    private static void DeleteOrder(IOrderService orderService)
    {
        Console.Write("Ange ID för den order att ta bort: ");
        var orderId = int.Parse(Console.ReadLine());

        orderService.DeleteOrder(orderId);
        Console.WriteLine("Order borttagen!");
    }

    private static void HandleProducts(IServiceProvider serviceProvider)
    {
        var productService = serviceProvider.GetService<IProductService>();
        var categoryService = serviceProvider.GetService<ICategoryService>();

        while (true) 
        {
            Console.WriteLine("\nHantering av produkter:");
            Console.WriteLine("1. Lägg till produkt");
            Console.WriteLine("2. Visa alla produkter");
            Console.WriteLine("3. Uppdatera produkt");
            Console.WriteLine("4. Ta bort produkt");
            Console.WriteLine("5. Tillbaka till huvudmenyn");
            Console.Write("Välj ett alternativ: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddProduct(productService, categoryService);
                    break;
                case "2":
                    ShowAllProducts(productService);
                    break;
                case "3":
                    UpdateProduct(productService, categoryService);
                    break;
                case "4":
                    DeleteProduct(productService);
                    break;
                case "5":
                    return; // Gå tillbaka till Huvudmenyn
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }
    }

    private static void AddProduct(IProductService productService, ICategoryService categoryService)
    {
        Console.Write("Ange produktnamn: ");
        var name = Console.ReadLine();

        Console.Write("Ange pris (endast siffror): ");
        decimal price;
        while (!decimal.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Ogiltigt prisformat. Ange priset igen (endast siffror):");
        }

        Console.Write("Ange beskrivning: ");
        var description = Console.ReadLine();

        Console.WriteLine("Tillgängliga kategorier:");
        var categories = categoryService.GetAllCategories();
        foreach (var category in categories)
        {
            Console.WriteLine($"ID: {category.CategoryId}, Namn: {category.Name}");
        }

        Console.Write("Ange kategori ID för produkten: ");
        int categoryId;
        while (!int.TryParse(Console.ReadLine(), out categoryId))
        {
            Console.WriteLine("Ogiltigt ID. Ange ett numeriskt värde.");
        }

        var categoryExists = categoryService.GetCategory(categoryId) != null;
        if (!categoryExists)
        {
            Console.WriteLine("Ingen kategori med angivet ID. Försök igen.");
            return;
        }

        var product = new Product { Name = name, Price = price, Description = description, CategoryId = categoryId };
        productService.AddProduct(product);
        Console.WriteLine("Produkt tillagd!");
    }

    private static void ShowAllProducts(IProductService productService)
    {
        var products = productService.GetAllProducts();

        foreach (var product in products)
        {
            Console.WriteLine($"Produkt ID: {product.ProductId}, Namn: {product.Name}, Pris: {product.Price:C}, Beskrivning: {product.Description}, Kategori ID: {product.CategoryId}");
        }
    }

    private static void UpdateProduct(IProductService productService, ICategoryService categoryService)
    {
        Console.Write("Ange ID för den produkt att uppdatera: ");
        if (!int.TryParse(Console.ReadLine(), out int productId))
        {
            Console.WriteLine("Ogiltigt ID-format.");
            return;
        }

        var product = productService.GetProduct(productId);
        if (product == null)
        {
            Console.WriteLine("Produkten hittades inte.");
            return;
        }

        Console.Write("Ange nytt produktnamn (lämna tomt för ingen ändring): ");
        var newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName))
        {
            product.Name = newName;
        }

        Console.Write("Ange nytt pris (lämna tomt för ingen ändring): ");
        var newPriceInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newPriceInput) && decimal.TryParse(newPriceInput, out var newPrice))
        {
            product.Price = newPrice;
        }

        Console.Write("Ange ny beskrivning (lämna tomt för ingen ändring): ");
        var newDescription = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newDescription))
        {
            product.Description = newDescription;
        }

        Console.Write("Ange ny kategori ID (lämna tomt för ingen ändring): ");
        var newCategoryIdInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newCategoryIdInput) && int.TryParse(newCategoryIdInput, out var newCategoryId))
        {
            var categoryExists = categoryService.GetCategory(newCategoryId) != null;
            if (categoryExists)
            {
                product.CategoryId = newCategoryId;
            }
            else
            {
                Console.WriteLine("Kategorin hittades inte.");
            }
        }

        try
        {
            productService.UpdateProduct(product);
            Console.WriteLine("Produkt uppdaterad!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ett fel inträffade vid uppdatering: {ex.Message}");
        }
    }

    private static void DeleteProduct(IProductService productService)
    {
        Console.Write("Ange ID för den produkt att ta bort: ");
        var productId = int.Parse(Console.ReadLine());

        productService.DeleteProduct(productId);
        Console.WriteLine("Produkt borttagen!");
    }

    private static void HandleCategories(IServiceProvider serviceProvider)
    {
        var categoryService = serviceProvider.GetService<ICategoryService>();

        while (true)
        {
            Console.WriteLine("\nHantering av kategorier:");
            Console.WriteLine("1. Lägg till kategori");
            Console.WriteLine("2. Visa alla kategorier");
            Console.WriteLine("3. Uppdatera kategori");
            Console.WriteLine("4. Ta bort kategori");
            Console.WriteLine("5. Tillbaka till huvudmenyn");
            Console.Write("Välj ett alternativ: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddCategory(categoryService);
                    break;
                case "2":
                    ShowAllCategories(categoryService);
                    break;
                case "3":
                    UpdateCategory(categoryService);
                    break;
                case "4":
                    DeleteCategory(categoryService);
                    break;
                case "5":
                    return; // Gå tillbaka till Huvudmenyn
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }
    }

    private static void AddCategory(ICategoryService categoryService)
    {
        Console.Write("Ange kategorinamn: ");
        string categoryName = Console.ReadLine();

        Category newCategory = new Category { Name = categoryName };
        categoryService.AddCategory(newCategory);
        Console.WriteLine("Kategori tillagd!");
    }

    private static void ShowAllCategories(ICategoryService categoryService)
    {
        var categories = categoryService.GetAllCategories();

        foreach (var category in categories)
        {
            Console.WriteLine($"Kategori-ID: {category.CategoryId}, Namn: {category.Name}");
        }
    }

    private static void UpdateCategory(ICategoryService categoryService)
    {
        Console.Write("Ange kategori-ID för uppdatering: ");
        if (!int.TryParse(Console.ReadLine(), out int categoryId))
        {
            Console.WriteLine("Ogiltigt ID-format.");
            return;
        }

        var category = categoryService.GetCategory(categoryId);

        if (category != null)
        {
            Console.Write("Ange nytt kategorinamn (lämna tomt för ingen ändring): ");
            string newName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newName))
            {
                category.Name = newName;
            }

            categoryService.UpdateCategory(category);
            Console.WriteLine("Kategori uppdaterad!");
        }
        else
        {
            Console.WriteLine($"Ingen kategori hittades med ID {categoryId}");
        }
    }

    private static void DeleteCategory(ICategoryService categoryService)
    {
        Console.Write("Ange kategori-ID för att radera: ");
        if (!int.TryParse(Console.ReadLine(), out int categoryId))
        {
            Console.WriteLine("Ogiltigt ID-format.");
            return;
        }

        categoryService.DeleteCategory(categoryId);
        Console.WriteLine("Kategori raderad!");
    }

    private static void HandleSuppliers(IServiceProvider serviceProvider)
    {
        var supplierService = serviceProvider.GetService<ISupplierService>();

        while (true) 
        {
            Console.WriteLine("\nHantering av leverantörer:");
            Console.WriteLine("1. Lägg till leverantör");
            Console.WriteLine("2. Visa alla leverantörer");
            Console.WriteLine("3. Uppdatera leverantör");
            Console.WriteLine("4. Ta bort leverantör");
            Console.WriteLine("5. Tillbaka till huvudmenyn");
            Console.Write("Välj ett alternativ: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddSupplier(supplierService);
                    break;
                case "2":
                    ShowAllSuppliers(supplierService);
                    break;
                case "3":
                    UpdateSupplier(supplierService);
                    break;
                case "4":
                    DeleteSupplier(supplierService);
                    break;
                case "5":
                    return; 
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }
    }

    private static void AddSupplier(ISupplierService supplierService)
    {
        // Lägger till en ny leverantör
        Console.Write("Ange leverantör namn: ");
        string supplierName = Console.ReadLine();

        Console.Write("Ange leverantör adress: ");
        string supplierAddress = Console.ReadLine();

        Console.Write("Ange leverantörs telefonnr: ");
        string supplierContactNumber = Console.ReadLine();

        Supplier newSupplier = new Supplier
        {
            Name = supplierName,
            Address = supplierAddress,
            ContactNumber = supplierContactNumber
        };
        supplierService.AddSupplier(newSupplier);
        Console.WriteLine("Leverantör tillagd!");
    }

    private static void ShowAllSuppliers(ISupplierService supplierService)
    {
        // Visar alla leverantörer
        var suppliers = supplierService.GetAllSuppliers();

        foreach (var supplier in suppliers)
        {
            Console.WriteLine($"Leverantör ID: {supplier.SupplierId}, Namn: {supplier.Name}, Adress: {supplier.Address}, Kontakt Nummer: {supplier.ContactNumber}");
        }
    }

    private static void UpdateSupplier(ISupplierService supplierService)
    {
        // Uppdaterar en befintlig leverantör
        Console.Write("Ange leverantörs ID för att uppdatera: ");
        if (!int.TryParse(Console.ReadLine(), out int supplierId))
        {
            Console.WriteLine("Ogiltigt ID-format.");
            return;
        }

        var supplier = supplierService.GetSupplier(supplierId);

        if (supplier != null)
        {
            Console.Write("Ange nytt leverantör namn (lämna tomt för ingen ändring): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                supplier.Name = newName;
            }

            Console.Write("Ange ny adress (lämna tomt för ingen ändring): ");
            string newAddress = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newAddress))
            {
                supplier.Address = newAddress;
            }

            Console.Write("Ange nytt kontakt nummer (lämna tomt för ingen ändring): ");
            string newContactNumber = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newContactNumber))
            {
                supplier.ContactNumber = newContactNumber;
            }

            supplierService.UpdateSupplier(supplier);
            Console.WriteLine("Leverantör uppdaterad!");
        }
        else
        {
            Console.WriteLine($"Ingen leverantör hittades med ID {supplierId}");
        }
    }

    private static void DeleteSupplier(ISupplierService supplierService)
    {
        // Tar bort en leverantör
        Console.Write("Ange leverantörs ID för att radera: ");
        if (!int.TryParse(Console.ReadLine(), out int supplierId))
        {
            Console.WriteLine("Ogiltigt ID-format.");
            return;
        }

        supplierService.DeleteSupplier(supplierId);
        Console.WriteLine("Leverantör raderad!");
    }

    private static void HandleOrderItems(IServiceProvider serviceProvider)
    {
        var orderItemService = serviceProvider.GetService<IOrderItemService>();

        while (true) 
        {
            Console.WriteLine("\nHantering av orderartiklar:");
            Console.WriteLine("1. Lägg till orderartikel");
            Console.WriteLine("2. Visa alla orderartiklar");
            Console.WriteLine("3. Uppdatera orderartikel");
            Console.WriteLine("4. Ta bort orderartikel");
            Console.WriteLine("5. Tillbaka till huvudmenyn");
            Console.Write("Välj ett alternativ: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddOrderItem(orderItemService);
                    break;
                case "2":
                    ShowAllOrderItems(orderItemService);
                    break;
                case "3":
                    UpdateOrderItem(orderItemService);
                    break;
                case "4":
                    DeleteOrderItem(orderItemService);
                    break;
                case "5":
                    return; 
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }
    }

    private static void AddOrderItem(IOrderItemService orderItemService)
    {
        Console.WriteLine("Lägg till orderartikel:");

        Console.Write("Ange order-ID: ");
        if (!int.TryParse(Console.ReadLine(), out int orderId))
        {
            Console.WriteLine("Ogiltigt format för order-ID.");
            return;
        }

        Console.Write("Ange produkt-ID: ");
        if (!int.TryParse(Console.ReadLine(), out int productId))
        {
            Console.WriteLine("Ogiltigt format för produkt-ID.");
            return;
        }

        Console.Write("Ange kvantitet: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity))
        {
            Console.WriteLine("Ogiltigt format för kvantitet.");
            return;
        }

        Console.Write("Ange pris: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            Console.WriteLine("Ogiltigt format för pris.");
            return;
        }

        var orderItem = new OrderItem
        {
            OrderId = orderId,
            ProductId = productId,
            Quantity = quantity,
            Price = price  // Sätter priset för orderartikeln
        };
        orderItemService.AddOrderItem(orderItem);
        Console.WriteLine("Orderartikel tillagd!");d
    }


    private static void ShowAllOrderItems(IOrderItemService orderItemService)
    {
        Console.WriteLine("Alla orderartiklar:"); 

        var orderItems = orderItemService.GetAllOrderItems();

        foreach (var orderItem in orderItems)
        {
            Console.WriteLine($"Orderartikel-ID: {orderItem.OrderItemId}, Order-ID: {orderItem.OrderId}, Produkt-ID: {orderItem.ProductId}, Kvantitet: {orderItem.Quantity}");
            
        }
    }

    private static void UpdateOrderItem(IOrderItemService orderItemService)
    {
        Console.Write("Ange orderartikels ID för uppdatering: "); 
        if (!int.TryParse(Console.ReadLine(), out int orderItemId))
        {
            Console.WriteLine("Ogiltigt format för orderartikel-ID."); 
        }

        var orderItem = orderItemService.GetOrderItem(orderItemId);

        if (orderItem != null)
        {
            Console.Write("Ange ny kvantitet (lämna tomt för ingen ändring): "); 
            if (int.TryParse(Console.ReadLine(), out int newQuantity))
            {
                orderItem.Quantity = newQuantity;
            }

            orderItemService.UpdateOrderItem(orderItem);
            Console.WriteLine("Orderartikel uppdaterad!"); 
        }
        else
        {
            Console.WriteLine($"Ingen orderartikel hittades med ID {orderItemId}"); 
        }
    }

    private static void DeleteOrderItem(IOrderItemService orderItemService)
    {
        Console.Write("Ange orderartikel-ID för att radera: "); 
        if (!int.TryParse(Console.ReadLine(), out int orderItemId))
        {
            Console.WriteLine("Ogiltigt format för orderartikel-ID."); 
            return;
        }

        orderItemService.DeleteOrderItem(orderItemId);
        Console.WriteLine("Orderartikel raderad!");
    }

}