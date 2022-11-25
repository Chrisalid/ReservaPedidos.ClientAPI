using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReservaPedidos.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ReservaPedidosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReservaPedidosContext") ?? throw new InvalidOperationException("Connection string 'ReservaPedidosContext' not found.")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
