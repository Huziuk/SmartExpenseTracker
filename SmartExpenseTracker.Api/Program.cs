using SmartExpenseTracker.Domain.Interfaces;
using SmartExpenseTracker.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient",
        policy =>
        {
            policy.WithOrigins("https://localhost:5207") 
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Swagger + OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

// Dependency Injection
builder.Services.AddSingleton<IExpenseService, ExpenseService>();

var app = builder.Build();

// Use CORS
app.UseCors("AllowBlazorClient");

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

// Middleware
app.UseHttpsRedirection();


// app.UseAuthorization();

app.MapControllers();

app.Run();