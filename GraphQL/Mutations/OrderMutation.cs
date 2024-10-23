using Pizzeria.Data.Entities;
using Pizzeria.Data;
using Pizzeria.Types;
using Pizzeria.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Pizzeria.GraphQL.Mutations
{
    public class OrderMutation
    {
        public async Task<Order> AddOrder(Order input, [Service] PizzeriaDbContext dbContext)
        {
            var order = new OrderEntity
            {
                CustomerName = input.CustomerName,
                CustomerPhone = input.CustomerPhone,
                CustomerAddress = input.CustomerAddress,
                PizzaType = input.PizzaType,
                Toppings = input.Toppings,
                PizzaSize = input.PizzaSize,
                Status = input.Status,
            };

            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync();

            return input with { Id = order.Id }; // Return the input with the new ID
        }

        public async Task<Order> UpdateOrder(int id, Order input, [Service] PizzeriaDbContext dbContext)
        {
            var order = await dbContext.Orders.FindAsync(id);
            if (order == null) throw new InvalidOperationException("Order not found.");

            order.Status = input.Status;
            order.PizzaType = input.PizzaType;
            order.Toppings = input.Toppings;
            await dbContext.SaveChangesAsync();
            return input with { Id = id };
        }

        public async Task<string> DeleteOrder(int id, [Service] PizzeriaDbContext dbContext)
        {
            var order = await dbContext.Orders.FindAsync(id);
            if (order == null) return "Order not found.";

            dbContext.Orders.Remove(order);
            await dbContext.SaveChangesAsync();
            return "Successfully deleted";
        }
    }
}
