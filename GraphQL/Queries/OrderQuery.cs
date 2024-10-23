using Pizzeria.Data;
using Pizzeria.Types;

namespace Pizzeria.GraphQL.Queries
{
    public class OrderQuery
    {
        public IQueryable<Order> GetOrders([Service] PizzeriaDbContext dbContext)
        {
            return dbContext.Orders.Select(o => new Order(
                o.Id,
                o.CustomerName,
                o.CustomerPhone,
                o.CustomerAddress,
                o.PizzaType,
                o.Toppings,
                o.PizzaSize,
                o.Status));
        }
    }
}
