using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.DTOs;
using RetailInventory.Models;

using var context = new AppDbContext();

Console.WriteLine("EF Core Demo");

bool exists = await context.Products
    .AnyAsync(p => p.Name == "Smartphone");

if (!exists)
{
    var mobile = new Product
    {
        Name = "Smartphone",
        Price = 25000,
        StockQuantity = 40,
        CategoryId = 1
    };

    await context.Products.AddAsync(mobile);

    await context.SaveChangesAsync();
}

var products = await context.Products
    .Include(p => p.Category)
    .ToListAsync();

Console.WriteLine("\nProducts");

foreach (var p in products)
{
    Console.WriteLine(

$"{p.Name}
₹{p.Price}
{p.Category?.Name}"

    );
}

var expensive = await context.Products
    .FirstOrDefaultAsync(p => p.Price > 50000);

Console.WriteLine(
$"\nExpensive Product : {expensive?.Name}");

var laptop = await context.Products
    .FirstOrDefaultAsync(
        p => p.Name == "Laptop");

if (laptop != null)
{
    laptop.Price = 70000;

    await context.SaveChangesAsync();
}

var rice = await context.Products
    .FirstOrDefaultAsync(
        p => p.Name == "Rice Bag");

if (rice != null)
{
    context.Products.Remove(rice);

    await context.SaveChangesAsync();
}

var dto = await context.Products

.Select(p => new ProductDTO
{
    Name = p.Name,

    CategoryName = p.Category.Name
})

.ToListAsync();

Console.WriteLine("\nDTO Data");

foreach (var item in dto)
{
    Console.WriteLine(

$"{item.Name}
{item.CategoryName}"

    );
}

var notracking = await context.Products
    .AsNoTracking()
    .ToListAsync();

Console.WriteLine(
$"\nNo Tracking Count : {notracking.Count}");