using Task.Views;
using Xamarin.Forms;

namespace Task
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TaskPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
