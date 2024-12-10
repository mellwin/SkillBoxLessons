using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAPI.AuthApp;
using WebAPI.DataContext;
using WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Добавление служб в контейнер DI.

// Настройка подключения к базе данных для телефонных контактов.
builder.Services.AddDbContext<PhoneContactContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Настройка подключения к базе данных для Identity.
builder.Services.AddDbContext<UserDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавление Identity.
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<UserDBContext>()
    .AddDefaultTokenProviders();

// Добавление репозитория.
builder.Services.AddScoped<IRepository, PhoneContactsDBRepo>();

// Добавление поддержки контроллеров Web API.
builder.Services.AddControllers(); // Используется вместо AddControllersWithViews для API-проекта.

// Добавление Swagger для документации API.
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Настройка конвейера HTTP-запросов.
if (!app.Environment.IsDevelopment())
{
    // Использование HSTS в продакшене.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Подключение аутентификации и авторизации.
app.UseAuthentication();
app.UseAuthorization();

// Регистрация маршрутов контроллеров.
app.MapControllers(); // Используется вместо app.RoutingRegistration для API-проекта.

app.Run();
