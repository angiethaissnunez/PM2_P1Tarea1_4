using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM2_P1Tarea1_4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
       

        private  void btnAgregar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.AddPage());
        }

        private async void btnlist_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.ListBD());
        }
    }
}
