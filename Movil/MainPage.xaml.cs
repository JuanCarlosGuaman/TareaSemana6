using Newtonsoft.Json;
using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Movil
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.0.112/moviles/post.php";
        private readonly HttpClient per = new HttpClient();
        private ObservableCollection<Movil.WS.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
            
        }
                       
        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await per.GetStringAsync(Url);
            List<Movil.WS.Datos> posts = JsonConvert.DeserializeObject<List<Movil.WS.Datos>>(content);
            _post = new ObservableCollection<Movil.WS.Datos>(posts);

            MyListView.ItemsSource = _post;
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VentanaIngreso());

        }
    }
}
