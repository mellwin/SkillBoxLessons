using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAPI.AuthApp;
using WebAPI.DataContext;
using WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// ���������� ����� � ��������� DI.

// ��������� ����������� � ���� ������ ��� ���������� ���������.
builder.Services.AddDbContext<PhoneContactContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ��������� ����������� � ���� ������ ��� Identity.
builder.Services.AddDbContext<UserDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ���������� Identity.
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<UserDBContext>()
    .AddDefaultTokenProviders();

// ���������� �����������.
builder.Services.AddScoped<IRepository, PhoneContactsDBRepo>();

// ���������� ��������� ������������ Web API.
builder.Services.AddControllers(); // ������������ ������ AddControllersWithViews ��� API-�������.

// ���������� Swagger ��� ������������ API.
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// ��������� ��������� HTTP-��������.
if (!app.Environment.IsDevelopment())
{
    // ������������� HSTS � ����������.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// ����������� �������������� � �����������.
app.UseAuthentication();
app.UseAuthorization();

// ����������� ��������� ������������.
app.MapControllers(); // ������������ ������ app.RoutingRegistration ��� API-�������.

app.Run();
