using HomeWorkWithUsers.PostgreMigration;
using AppDAL.EF;
using Microsoft.EntityFrameworkCore;
using AppDAL.Interfaces;
using LayerApp.BLL.Interfaces;
using AppDAL.Repositories;
using LayerApp.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
 
var dbType = builder.Configuration["DbConfig:Type"];
var connectionString = builder.Configuration.GetConnectionString("NpgsqlConnectionString");
if (connectionString != null) {
    PostgreMigration.Migrate(connectionString);
}


builder.Services.AddDbContext<AppDBContext>(options => options.UseNpgsql(connectionString));

// внедрение зависимостей
builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TaskService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

