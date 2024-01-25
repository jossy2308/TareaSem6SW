using Newtonsoft.Json;
using System.Collections.ObjectModel;
using TareaSem6SW.Models;

namespace TareaSem6SW.Vista;

public partial class Principal : ContentPage
{
    private const string Url = "http://192.168.100.7/moviles/post.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Transporte> transp;
    public Principal()
	{
		InitializeComponent();
        Obtener();
    }
    public async void Obtener()
    {
        var content = await cliente.GetStringAsync(Url);
        List<Transporte> mostrarTrans = JsonConvert.DeserializeObject<List<Transporte>>(content);
        transp = new ObservableCollection<Transporte>(mostrarTrans);
        listaTransportes.ItemsSource = transp;
    }

  
}