var builder = WebApplication.CreateBuilder(args); // Create a new WebApplication instance with default settings.

// Add services to the dependency injection container.

builder.Services.AddControllers(); // Register controllers to handle API requests.

builder.Services.AddEndpointsApiExplorer(); // Enables API explorer (required for minimal APIs and Swagger).
builder.Services.AddSwaggerGen(); // Registers Swagger for API documentation.

builder.Services.AddLogging(); // Enables logging services for debugging and diagnostics.

// Configure CORS (Cross-Origin Resource Sharing) policy.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // Allow requests from any origin (for testing; restrict in production).
              .AllowAnyMethod()   // Allow all HTTP methods (GET, POST, PUT, DELETE, etc.).
              .AllowAnyHeader();  // Allow any headers in the request.
    });
});

var app = builder.Build(); // Build the application pipeline.

// Configure middleware for handling HTTP requests.

if (app.Environment.IsDevelopment()) // Only enable Swagger in development mode.
{
    app.UseSwagger();    // Enables Swagger JSON endpoint for API documentation.
    app.UseSwaggerUI();  // Provides a user-friendly Swagger UI to test APIs.
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS (recommended for security).

app.UseCors("AllowAll"); // Apply the configured CORS policy globally.

app.UseAuthorization(); // Enables authorization (required if using authentication/role-based access control).

app.MapControllers(); // Maps controller routes, making API endpoints accessible.

app.Run(); // Start listening for incoming HTTP requests.
