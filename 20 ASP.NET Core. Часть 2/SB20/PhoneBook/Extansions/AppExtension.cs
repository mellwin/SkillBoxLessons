namespace PhoneBook.Extansions
{
    public static class AppExtension
    {
        public static void RoutingRegistration(this WebApplication app)
        {
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=PhoneContact}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "ShowEdit",
                pattern: "{controller=PhoneContact}/{action=Details}/{id?}");

            app.MapControllerRoute(
                name: "CreatePhoneContact",
                pattern: "{controller=PhoneContact}/{action=CreatePhoneContact}/{id?}");
        }
    }
}
