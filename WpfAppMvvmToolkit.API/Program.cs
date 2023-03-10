using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyToDo.Api.Extensions;
using WpfAppMvvmToolkit.API.Context;
using WpfAppMvvmToolkit.API.Context.Entities;
using WpfAppMvvmToolkit.API.Context.Repositories;
using WpfAppMvvmToolkit.API.Context.UnitOfWork;
using WpfAppMvvmToolkit.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();






builder.Services.AddDbContext<MvvmToolkitContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DbConnection");
    options.UseSqlite(connectionString);

}).AddUnitOfWork<MvvmToolkitContext>()
.AddCustomRepository<User, UserRepository>();
//????AutoMapper
var autoMapperConfig = new MapperConfiguration(config =>
{
    config.AddProfile(new AutoMapperProFile());

});

builder.Services.AddSingleton(autoMapperConfig.CreateMapper());


builder.Services.AddTransient<IFileService, FileService>();

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

app.Run();
