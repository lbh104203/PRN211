using TripApplication.GUI;

namespace TripApplication
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new BookingGUI("admin", "admin", 1));
            Application.Run(new LoginGUI());
        }
    }
}