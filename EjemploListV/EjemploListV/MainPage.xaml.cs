using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EjemploListV
{
    public partial class MainPage : ContentPage
    {
        [DesignTimeVisible(false)]
        public class Fruta
        {
            public string Nombre { get; set; }
            public string Url { get; set; }
        }

        ObservableCollection <Fruta> datos = new ObservableCollection<Fruta>();
        public MainPage()
        {
            InitializeComponent();
            milista.ItemsSource = datos;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            datos.Add(new Fruta { Nombre = valor.Text, Url = direccionurl.Text });
            valor.Text = "";
            direccionurl.Text = "";
        }

        async private void milista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var myListView = (ListView)sender;
            var myItem = myListView.SelectedItem;
            int index = datos.IndexOf(myItem);
            string action = await DisplayActionSheet("Acciones:",
                "Cancelar", null, "Eliminar", "Editar");
            if(action=="Eliminar")
            {
                datos.RemoveAt(index);
                await DisplayAlert("Mensaje", "Se eliminó el elemento no." + index+1, "ok");
            }
            if(action=="Editar")
            {
                await DisplayAlert("Mensaje", "Seleccionó Editar", "ok");
            }
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var mifruta = (MenuItem)sender;
            DisplayAlert("Fruta seleccionada:", "Fruta " + mifruta.CommandParameter.ToString(), "ok");
        }

        private void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            DisplayAlert("Mensaje", "Seleccionó borrar", "ok");

        }
    }
}
