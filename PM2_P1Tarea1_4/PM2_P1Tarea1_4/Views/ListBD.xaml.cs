using PM2_P1Tarea1_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2_P1Tarea1_4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListBD : ContentPage
    {
        public ListBD()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                listImage.ItemsSource = await App.DBase.getListImagen();
            }
            catch (Exception)
            {

            }
        }

        private async void toolMenu1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.AddPage());
        }

        private async void toolMenu2_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageLocal());

        }

        private async void listImage_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selected = e.Item as Imagen;

            PageImage viewEmple = new PageImage();
            viewEmple.BindingContext = selected;

            await Navigation.PushAsync(viewEmple);

        }
    }
}