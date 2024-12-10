namespace WebApp.Extansions
{
    public static class AppExtension
    {
        public static void RoutingRegistration(this WebApplication app)
        {
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=PhoneContact}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "details",
                pattern: "{controller=PhoneContact}/{action=Details}/{id?}");
        }
    }
}
