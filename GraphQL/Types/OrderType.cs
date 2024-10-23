using Pizzeria.Data.Entities;

namespace Pizzeria.GraphQL.Types
{
    public class OrderType : ObjectType<OrderEntity>
    {
        protected override void Configure(IObjectTypeDescriptor<OrderEntity> descriptor)
        {
            descriptor.Field(o => o.Id).Type<NonNullType<IdType>>();
            descriptor.Field(o => o.CustomerName).Type<NonNullType<StringType>>();
            descriptor.Field(o => o.CustomerPhone).Type<NonNullType<StringType>>();
            descriptor.Field(o => o.CustomerAddress).Type<NonNullType<StringType>>();
            descriptor.Field(o => o.PizzaType).Type<NonNullType<StringType>>();
            descriptor.Field(o => o.Toppings).Type<NonNullType<ListType<StringType>>>();
            descriptor.Field(o => o.Status).Type<NonNullType<StringType>>();
        }
    }
}
