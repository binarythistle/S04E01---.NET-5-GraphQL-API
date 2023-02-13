using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using CommanderGQL.GraphQL.Commands;
using Microsoft.EntityFrameworkCore;
using CommanderGQL.GraphQL.Platforms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPooledDbContextFactory<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("CommandConStr")));
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddType<PlatformType>()
    .AddType<CommandType>()
    .AddFiltering()
    .AddSorting()
    .AddInMemorySubscriptions();

var app = builder.Build();
app.UseWebSockets();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});
app.UseGraphQLVoyager("/graphql-voyager", new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
});

app.Run();