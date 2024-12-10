using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhoneBook.AuthApp;
using PhoneBook.Data;
using PhoneBook.DataContext;
using PhoneBook.Extansions;

var builder = WebApplication.CreateBuilder(args);

// Добавьте службы в контейнер.
builder.Services.AddControllersWithViews();

// Добавление контекста для телефонных контактов
builder.Services.AddDbContext<PhoneContactContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
    ServiceLifetime.Scoped);

// Добавление контекста для Identity
builder.Services.AddDbContext<UserDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
    ServiceLifetime.Scoped);

// Добавление Identity
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<UserDBContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IRepository, PhoneContactsDBRepo>();

builder.Services.AddControllersWithViews();


var app = builder.Build();

// Настройте конвейер HTTP-запросов.
if (!app.Environment.IsDevelopment())
{
    // По умолчанию значение HSTS составляет 30 дней. Вы можете изменить это значение для производственных сценариев, см. https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.RoutingRegistration();

app.Run();