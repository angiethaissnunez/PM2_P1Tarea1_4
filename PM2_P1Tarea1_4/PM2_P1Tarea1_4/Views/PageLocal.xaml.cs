using PM2_P1Tarea1_4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2_P1Tarea1_4.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageLocal : ContentPage
	{
		public PageLocal ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            string folderPath = "/storage/emulated/0/Android/data/com.companyname.pm2_p1tarea1_4/files/Pictures/MisFotos/";


            try
            {
                string[] files = Directory.GetFiles(folderPath, "*.jpg");

                List<Imagen> imagenes = new List<Imagen>();

                Imagen temp = null;
                foreach (var item in files)
                {
                    temp = new Imagen();

                    temp.nombre = item.Remove(0, 82);
                    temp.descripcion = item;
                    temp.foto = FileToByteArray(item);

                    imagenes.Add(temp);
                }

                listaImagen.ItemsSource = imagenes;
            }
            catch (Exception)
            {

            }
        }


        private async void listaImagen_ItemTapped(object sender, ItemTappedEventArgs e)
		{

            var selected = e.Item as Imagen;
                 
            PageImage viewEmple = new PageImage();
            viewEmple.BindingContext = selected;

            await Navigation.PushAsync(viewEmple);

        }

        public byte[] FileToByteArray(string fileName)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName,
                                           FileMode.Open,
                                           FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }

    }
}