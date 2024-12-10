using PhoneBook.Extansions;
using PhoneBook.Models;

var builder = WebApplication.CreateBuilder(args);

// Добавьте службы в контейнер.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepository, PhoneContactsDBRepo>();

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