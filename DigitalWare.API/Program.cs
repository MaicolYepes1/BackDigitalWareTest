using AutoMapper;
using DigitalWare.DATA.Context;
using DigitalWare.IOC;
using DigitalWare.MODELS.Mapping;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region RegisterDependencies
RegisterDependency.RegisterServices(builder.Services);
#endregion

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
#region RegisterAddCors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("*")
                          .AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});
#endregion


#region AddAutomapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new Automaping());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

#region Context
builder.Services.AddDbContext<DigitalWareDBContext>(options =>
      options
      .UseLazyLoadingProxies()
      .UseSqlServer(builder.Configuration.GetConnectionString("connection"))
      );
#endregion

builder.Services.AddControllers();
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

app.Run();
