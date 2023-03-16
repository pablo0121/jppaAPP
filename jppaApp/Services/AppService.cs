using jppaApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace jppaApp.Services
{
    public class AppService
    {
        public static AppService Instancia = new AppService();

        public async Task<string> IniciarSesionAsync(string usuario, string password)
        {
            string result = "";

            // TO DO: GENERAR EL BODY PARA EL ENVIO DE LOS DATOS 
            Login login = new Login()
            {
                username = usuario,
                password = password
            };

            // TO DO : GENERAR LA ESTRCUTURA JSON DEL OBJETO LOGIN 
            string json = JsonConvert.SerializeObject(login);

            // TO DO: CONIGURAR LA PETICIÓN PARA EL ENVIO DE LOS DATOS
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // TO DO : ENVIAR LA PETICIÓN POST
            var handler = new HttpClientHandler();
            handler.UseProxy = false; 

            HttpClient client = new HttpClient(handler);
            var reponse = await client.PostAsync($"{Utils.Utils.API_URL}/auth", content);
            result = await reponse.Content.ReadAsStringAsync();

            return result; 
        }
    }
}
