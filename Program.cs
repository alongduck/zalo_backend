using GraphQL.Server;
using Microsoft.EntityFrameworkCore;
using zalo_server.SkyEagle.GraphQL;
using zalo_server.SkyEagle.GraphQL.Type;
using zalo_server.SkyModel;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.AllowSynchronousIO = true; // Allows synchronous I/O
});

// Add services to the container.
builder.Services.AddControllers();

// Add OpenAPI documentation
builder.Services.AddOpenApi();

// Configure DbContext to use SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register GraphQL services
builder.Services.AddScoped<Query>();
builder.Services.AddScoped<Mutation>();
builder.Services.AddScoped<AppSchema>(); // Schema depends on both Query and Mutation
builder.Services.AddScoped<ProductType>();
builder.Services.AddScoped<DetailType>();
builder.Services.AddScoped<CategoryType>();
builder.Services.AddScoped<UserType>();

// Configure GraphQL and serialization
builder.Services.AddGraphQL(options =>
{
    options.EnableMetrics = true; // Enable metrics for debugging and tracing
})
.AddNewtonsoftJson() // Alternatively, use AddNewtonsoftJson() if preferred
.AddGraphTypes(ServiceLifetime.Scoped); // Ensure all GraphQL types are scoped

// Register controllers
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // Enable OpenAPI for development
}
app.UseCors("AllowAllOrigins"); // Use the CORS policy


app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
app.UseAuthorization(); // Authorization middleware

app.MapControllers(); // Map API controllers

// Configure GraphQL middleware
app.UseGraphQL<AppSchema>();
app.UseGraphQLPlayground("/graphql/playground"); // GraphQL Playground for query testing

app.Run(); // Start the application
