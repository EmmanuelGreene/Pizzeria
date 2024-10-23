using Pizzeria.Data.Enums;

namespace Pizzeria.Types
{
    public record Order(
        int? Id,
        string CustomerName,
        string CustomerPhone,
        string CustomerAddress,
        string PizzaType,
        string Toppings,
        PizzaSize PizzaSize,
        OrderStatus Status);
}
