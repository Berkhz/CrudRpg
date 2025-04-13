using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Rpg.Src.Context;
using Rpg.Src.Business;
using Rpg.Src.Business.Interface;
using Rpg.Src.repository;
using Rpg.Src.repository.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RpgContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RpgDB;Trusted_Connection=True;"));

builder.Services.AddScoped<IPersonagemRepository, PersonagemRepository>();
builder.Services.AddScoped<IItemMagicoRepository, ItemMagicoRepository>();
builder.Services.AddScoped<IPersonagemBusiness, PersonagemBusiness>();
builder.Services.AddScoped<IItemMagicoBusiness, ItemMagicoBusiness>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();