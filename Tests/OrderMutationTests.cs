using Microsoft.EntityFrameworkCore;
using Pizzeria.Data;
using Pizzeria.Data.Entities;
using Pizzeria.Data.Enums;
using Pizzeria.GraphQL.Mutations;
using Pizzeria.GraphQL.Queries;
using Pizzeria.Types;
using Xunit;

namespace Pizzeria.Tests
{
    public class OrderMutationTests : IDisposable // Implement IDisposable for cleanup
    {
        private readonly PizzeriaDbContext _dbContext;
        private readonly OrderMutation _orderMutation;

        public OrderMutationTests()
        {
            // Create a new InMemory Database for tests
            var options = new DbContextOptionsBuilder<PizzeriaDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Use unique DB name for isolation
                .Options;

            _dbContext = new PizzeriaDbContext(options);
            _orderMutation = new OrderMutation();

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            // Add initial data to the in-memory database
            _dbContext.Orders.AddRange(new List<OrderEntity>
            {
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
                }
            });
            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task AddOrder_ShouldAddNewOrder()
        {
            var newOrder = new Order(3, "Alice Johnson", "111-222-3333", "789 Pine St, Springfield", "BBQ Chicken", "Onions, Peppers", PizzaSize.Medium, OrderStatus.Baked);
            
            var result = await _orderMutation.AddOrder(newOrder, _dbContext);

            Assert.NotNull(result);
            Assert.Equal(newOrder.CustomerName, result.CustomerName);
            Assert.Equal(newOrder.PizzaType, result.PizzaType);

            var addedOrder = await _dbContext.Orders.FindAsync(result.Id);
            Assert.NotNull(addedOrder);
        }

        [Fact]
        public async Task UpdateOrder_ShouldChangeOrderDetails()
        {
            var orderToUpdate = new Order(1, "John Doe", "123-456-7890", "123 Main St, Springfield", "Margherita", "Olive, Basil", PizzaSize.Medium, OrderStatus.Preparing);

            var result = await _orderMutation.UpdateOrder(orderToUpdate.Id, orderToUpdate, _dbContext);

            Assert.Equal(orderToUpdate.Status, result.Status);
        }

        [Fact]
        public async Task DeleteOrder_ShouldRemoveOrder()
        {
            var orderIdToDelete = 2;

            var result = await _orderMutation.DeleteOrder(orderIdToDelete, _dbContext);

            Assert.Equal("Successfully deleted", result);

            var deletedOrder = await _dbContext.Orders.FindAsync(orderIdToDelete);
            Assert.Null(deletedOrder); // Order should no longer exist
        }

        [Fact]
        public void GetOrders_ShouldReturnAllOrders()
        {
            var orderQuery = new OrderQuery();

            var orders = orderQuery.GetOrders(_dbContext).ToList();

            Assert.Equal(2, orders.Count); // Ensure two orders exist
        }

        // Explicit cleanup if needed
        public void Dispose()
        {
            _dbContext?.Database.EnsureDeleted(); // Clean up the database explicitly if necessary
            _dbContext?.Dispose(); // Dispose of the DbContext
        }
    }
}
