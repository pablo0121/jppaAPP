using jppaApp.Models;
using jppaApp.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace jppaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        /* Nombre: Juan Pablo Palma Apoderado No.Control: 1221100259 */
        private async void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool esValido = ValidarFormulario();
                if (esValido == true)
                {
                    using (await MaterialDialog.Instance.LoadingDialogAsync("Espere por favor"))
                    {
                        string usuario = TxtUsuario.Text;
                        string password = TxtPassword.Text;
                        string json = await AppService.Instancia.IniciarSesionAsync(usuario, password);
                        Auth auth =  JsonConvert.DeserializeObject<Auth>(json);
                        await MaterialDialog.Instance.SnackbarAsync(auth.mensaje);

                        // TO DO: REDIRECCION A LA PAGINA DE INICIO
                        if (!string.IsNullOrEmpty(auth.token))
                        {
                            // TO DO: Guardar la información  del usuario 

                            // TO DO: Verificar que la clave 'usuario' no exista , si existe se debe de eliminar 
                            if (Application.Current.Properties.ContainsKey("usuario"))
                            {
                                Application.Current.Properties.Remove("usuario");
                            }
                            // TO DO: Guardar la información de un formato de tipo json => variable json 
                            Application.Current.Properties.Add("usuario", json);
                            // TO DO: Realizar la persistencia de los datos
                            await Application.Current.SavePropertiesAsync(); 
                            //Se redireccionaa  al pantalla de inicio 
                            Application.Current.MainPage = new InicioPage(); 

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                await MaterialDialog.Instance.AlertAsync(ex.Message, "Error", "Aceptar"); 
            }
        }

        private bool ValidarFormulario()
        {
            TxtUsuario.HasError = false;
            TxtPassword.HasError = false;
            bool bandera = true; 
            if (TxtUsuario.Text.Trim() == "")
            {
        
                bandera = false;
                TxtUsuario.HasError = true;
                TxtUsuario.ErrorText = "El usuario es requerdio"; 

            }
            // TO DO: Validar el usuario
            if (TxtUsuario.Text.Trim() == "")
            {
                bandera = false;
                TxtPassword.HasError = true;
                TxtPassword.ErrorText = "La contraseña es requerida"; 
            }
            return bandera;
        }
    }
}