var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Registering controllers (important for API routing)
builder.Services.AddControllers();

// Add OpenAPI (Swagger) support (optional for documentation)
builder.Services.AddOpenApi();

// Add CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // Allow any origin for testing (change in production!)
              .AllowAnyMethod()   // Allow any HTTP method (GET, POST, etc.)
              .AllowAnyHeader();  // Allow any header
    });
});

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    // Enable OpenAPI (Swagger) for development environment
    app.MapOpenApi();
}

// Enable HTTPS redirection (optional but recommended for production)
app.UseHttpsRedirection();

// Enable CORS globally for all endpoints (using the "AllowAll" policy)
app.UseCors("AllowAll");

// Map the controllers to API routes
app.MapControllers();

// Run the application
app.Run();
