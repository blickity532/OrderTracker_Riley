using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<OrderTrackerContext>(options =>
    options.UseInMemoryDatabase("OrderTrackerDB")); // Use InMemoryDatabase for simplicity

var context = scope.ServiceProvider.GetRequiredService<OrderTrackerContext>();
context.Database.EnsureCreated();


var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

public class Class1
{
	public Class1()
	{
	}
}
