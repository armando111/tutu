using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var config = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(x => x
    .UseSqlite(config.GetConnectionString("Default")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    //Mine
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

//Mine
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
