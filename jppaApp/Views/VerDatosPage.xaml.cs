using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jppaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerDatosPage : ContentPage
    {
        /* Nombre: Juan Pablo Palma Apoderado No.Control: 1221100259 */
        public VerDatosPage()
        {
            InitializeComponent();

            // TO DO: Crear una lista de objetos con l¿valores aleatorios 
            // Label: Texto que mostrara la grafica
            // ValueLabel : el Valor del elemento a mostrar
            // Color: El color del rango del valor 
            var entries = new[]
            {
                new ChartEntry(21){
                    Label = DateTime.Now.ToString("dd/MM/yyyy"),
                    ValueLabel = "21°C°",
                    Color = SKColor.Parse(GetColor())
                },
                new ChartEntry(51){
                    Label = DateTime.Now.ToString("dd/MM/yyyy"),
                    ValueLabel = "51°C°",
                    Color = SKColor.Parse(GetColor())
                },
                new ChartEntry(29){
                    Label = DateTime.Now.ToString("dd/MM/yyyy"),
                    ValueLabel = "29°C°",
                    Color = SKColor.Parse(GetColor())

                }
            };
            var chart = new PieChart() { Entries = entries, LabelTextSize=40}; 
            chartTemperatura.Chart = chart;
        }
         private string GetColor()
        {
            var random = new Random();
            return String.Format("#{0:X6}", random.Next(0x1000000)); 
        }
    }
}