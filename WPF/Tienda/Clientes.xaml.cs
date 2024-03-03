
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CRUD.Model.Entidades;

namespace Tienda
{
    /// <summary>
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : Window
    {
        HttpClient cliente = new HttpClient();
        public Clientes()
        {
            cliente.BaseAddress = new Uri("http://localhost:6794/api/");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            InitializeComponent();
        }

        private void btncarga_Click(object sender, RoutedEventArgs e)
        {
            GetClientes();
        }

        private async void GetClientes()
        {
            var response = await cliente.GetStringAsync("Clientes/GetClientes");
            var clientes = JsonConvert.DeserializeObject<List<ClientesVO>>(response);
            dg.DataContext = clientes;

        }

        private async void GuardaCliente(ClientesVO cli)
        {
            await cliente.PostAsJsonAsync("Clientes/CreaActualizaClientes", cli);
            GetClientes();
        }

        private async void BorraCliente(int idcliente)
        {
            await cliente.DeleteAsync("Clientes/BajaClientes?input=" + idcliente);
        }

        private void btnguarda_Click(object sender, RoutedEventArgs e)
        {

            if(string.IsNullOrEmpty(nombre.Text)|| string.IsNullOrEmpty(correo.Text)||
                string.IsNullOrEmpty(direccion.Text)||string.IsNullOrEmpty(password.Password.ToString()))
            {

                lblMessage.Content = "Favor de capturar los datos obligatorios";
                return;
            }

            var cliente = new ClientesVO()
            {

                IdCliente = string.IsNullOrEmpty(idcliente.Text) ? 0 : Convert.ToInt32(idcliente.Text),
                Nombre = nombre.Text,
                Apellidos = apellidos.Text,
                Direccion = direccion.Text,
                Correo = correo.Text,
                Password = password.Password.ToString()
            };

            this.GuardaCliente(cliente);
            lblMessage.Content = "Exito";
            nombre.Text = string.Empty;
            apellidos.Text = String.Empty;
            direccion.Text = string.Empty;
            correo.Text = string.Empty;
            password.Password = string.Empty;
        }

        void btnEditar(object sender, RoutedEventArgs e)
        {
            ClientesVO cli = ((FrameworkElement)sender).DataContext as ClientesVO;
            idcliente.Text = cli.IdCliente.ToString();
            nombre.Text = cli.Nombre.ToString();
            apellidos.Text = cli.Apellidos.ToString();
            direccion.Text = cli.Direccion.ToString();
            correo.Text = cli.Correo.ToString();
            GetClientes();
        }

        void btnElimna(object sender, RoutedEventArgs e)
        {
            ClientesVO cli = ((FrameworkElement)sender).DataContext as ClientesVO;
            this.BorraCliente(cli.IdCliente);
            GetClientes();
        }

    }
}
