using WebApp.Extansions;

var builder = WebApplication.CreateBuilder(args);

// �������� ������ � ���������.
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