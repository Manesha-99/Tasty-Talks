using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Tasty_Talks_BackEnd.Data;
using Tasty_Talks_BackEnd.Mapping;
using Tasty_Talks_BackEnd.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<TastyTalksDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));


builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IShopsRepository, SQLShopsRepository>();
builder.Services.AddScoped<IUsersRepository, SQLUsersRepository>();
builder.Services.AddScoped<IFoodCategoryRepository, SQLFoodCategoryRepository>();
builder.Services.AddScoped<IFoodRepository, SQLFoodRepository>();
builder.Services.AddScoped<IOrderRepository, SQLOrderRepository>();
builder.Services.AddScoped<IImageRepository, SQLImageRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images"
}
);

app.MapControllers();

app.Run();
