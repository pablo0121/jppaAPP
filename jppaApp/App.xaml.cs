using jppaApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jppaApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            XF.Material.Forms.Material.Init(this);
            // TO DO: Verificar si existe la clave "usuario", si existe la pantalla de inicio 
            // si no se debe mostrar la pantalla de incio de sesión 
            if (Application.Current.Properties.ContainsKey("usuario"))
            {
                MainPage = new NavigationPage(new InicioPage()); 
            }
            else
            {
                MainPage = new LoginPage();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
