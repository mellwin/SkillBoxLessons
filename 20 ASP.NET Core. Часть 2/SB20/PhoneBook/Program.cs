using PhoneBook.Extansions;
using PhoneBook.Models;

var builder = WebApplication.CreateBuilder(args);

// �������� ������ � ���������.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepository, PhoneContactsDBRepo>();

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