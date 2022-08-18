using Microsoft.EntityFrameworkCore;
using NailsByNikki.Data;
using NailsByNikki.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// add database context
builder.Services.AddDbContext<NailsByNikkiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NailsByNikki"));
});

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingHistoryRepository, BookingHistoryRepository>();
builder.Services.AddScoped<IAvailableSlotRepository, AvailableSlotRepository>();

builder.Services.AddControllers();
builder.Services.AddMvc();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.CreateDbIfNotExists();

app.Run();

// public declaration needed for test project
public partial class Program {}