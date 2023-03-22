using HomeWorkWithUsers.Data.Interface;
using HomeWorkWithUsers.Data.Mocks;
using HomeWorkWithUsers.Data.Repository;
using HomeWorkWithUsers.PostgreMigration;
//using HomeWorkWithUsers.Data.Mocks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var dbType = builder.Configuration["DbConfig:Type"];
var connectionString = builder.Configuration.GetConnectionString("NpgsqlConnectionString");
switch (dbType) {
    case "Postgres":
        PostgreMigration.Migrate(connectionString);
        builder.Services.AddScoped<IUserRepository, UserMockRepository>(provider => new UserMockRepository(connectionString));
        builder.Services.AddScoped<ITaskRepository, TaskMockRepository>(provider => new TaskMockRepository(connectionString));
        break;
    case "Mock":
        builder.Services.AddTransient<IAllUsers, MockUsers>();
        builder.Services.AddTransient<IAllTasks, MockTasks>();
        break;
}



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

