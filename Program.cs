using Microsoft.EntityFrameworkCore;
using Pizzeria.Data;
using Pizzeria.GraphQL.Mutations;
using Pizzeria.GraphQL.Queries;
using Pizzeria.GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PizzeriaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<OrderQuery>()
    .AddMutationType<OrderMutation>()
    .AddType<OrderType>();

var app = builder.Build();

app.UseRouting();

app.MapGraphQL();

app.Run("http://0.0.0.0:5000");