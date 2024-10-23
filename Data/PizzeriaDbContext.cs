using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Data.Entities;
using Pizzeria.Data.Enums;

namespace Pizzeria.Data
{
    public class PizzeriaDbContext : DbContext
    {
        public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options) : base(options) { }

        public DbSet<OrderEntity> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderEntity>().HasData(
                new OrderEntity
                {
                    Id = 1,
                    CustomerName = "John Doe",
                    CustomerPhone = "123-456-7890",
                    CustomerAddress = "123 Main St, Springfield",
                    PizzaType = "Margherita",
                    Toppings = "Olive, Basil",
                    PizzaSize = PizzaSize.Medium,
                    Status = OrderStatus.Delivered
                },
                new OrderEntity
                {
                    Id = 2,
                    CustomerName = "Jane Smith",
                    CustomerPhone = "987-654-3210",
                    CustomerAddress = "456 Elm St, Springfield",
                    PizzaType = "Pepperoni",
                    Toppings = "Extra Cheese, Jalapenos",
                    PizzaSize = PizzaSize.Large,
                    Status = OrderStatus.Preparing
                },
                new OrderEntity
                {
                    Id = 3,
                    CustomerName = "Sam Brown",
                    CustomerPhone = "555-555-5555",
                    CustomerAddress = "789 Maple St, Springfield",
                    PizzaType = "BBQ Chicken",
                    Toppings = "Onions, Peppers",
                    PizzaSize = PizzaSize.Small,
                    Status = OrderStatus.Baked
                },
                new OrderEntity
                {
                    Id = 4,
                    CustomerName = "Emily Davis",
                    CustomerPhone = "444-444-4444",
                    CustomerAddress = "321 Oak St, Springfield",
                    PizzaType = "Vegetarian",
                    Toppings = "Mushrooms, Spinach, Feta",
                    PizzaSize = PizzaSize.Medium,
                    Status = OrderStatus.Delivered
                },
                new OrderEntity
                {
                    Id = 5,
                    CustomerName = "Michael Johnson",
                    CustomerPhone = "111-222-3333",
                    CustomerAddress = "654 Pine St, Springfield",
                    PizzaType = "Hawaiian",
                    Toppings = "Pineapple, Ham",
                    PizzaSize = PizzaSize.Medium,
                    Status = OrderStatus.Delivered
                },
                new OrderEntity
                {
                    Id = 6,
                    CustomerName = "Sarah Wilson",
                    CustomerPhone = "222-333-4444",
                    CustomerAddress = "987 Birch St, Springfield",
                    PizzaType = "Meat Lovers",
                    Toppings = "Pepperoni, Sausage, Bacon",
                    PizzaSize = PizzaSize.Medium,
                    Status = OrderStatus.Delivered
                },
                new OrderEntity
                {
                    Id = 7,
                    CustomerName = "David Lee",
                    CustomerPhone = "333-444-5555",
                    CustomerAddress = "234 Cedar St, Springfield",
                    PizzaType = "Four Cheese",
                    Toppings = "Cheddar, Mozzarella, Blue Cheese, Parmesan",
                    PizzaSize = PizzaSize.Medium,
                    Status = OrderStatus.Preparing
                },
                new OrderEntity
                {
                    Id = 8,
                    CustomerName = "Lisa Taylor",
                    CustomerPhone = "555-666-7777",
                    CustomerAddress = "890 Spruce St, Springfield",
                    PizzaType = "Buffalo Chicken",
                    Toppings = "Hot Sauce, Ranch",
                    PizzaSize = PizzaSize.Small,
                    Status = OrderStatus.Baked
                }
            );

        }
    }
}