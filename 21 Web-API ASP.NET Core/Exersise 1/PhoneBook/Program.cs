using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhoneBook.AuthApp;
using PhoneBook.Data;
using PhoneBook.DataContext;
using PhoneBook.Extansions;

var builder = WebApplication.CreateBuilder(args);

// �������� ������ � ���������.
builder.Services.AddControllersWithViews();

// ���������� ��������� ��� ���������� ���������
builder.Services.AddDbContext<PhoneContactContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
    ServiceLifetime.Scoped);

// ���������� ��������� ��� Identity
builder.Services.AddDbContext<UserDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
    ServiceLifetime.Scoped);

// ���������� Identity
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<UserDBContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IRepository, PhoneContactsDBRepo>();

builder.Services.AddControllersWithViews();


var app = builder.Build();

// ��������� �������� HTTP-��������.
if (!app.Environment.IsDevelopment())
{
    // �� ��������� �������� HSTS ���������� 30 ����. �� ������ �������� ��� �������� ��� ���������������� ���������, ��. https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.RoutingRegistration();

app.Run();