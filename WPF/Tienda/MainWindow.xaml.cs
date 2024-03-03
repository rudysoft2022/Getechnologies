
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
using System.Windows.Threading;

namespace Tienda
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        double panelWidth;
        bool hidden;
     public MainWindow() { 
        
            InitializeComponent();
            timer=new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;
            panelWidth = sidePAnel.Width;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (hidden)
            {
                sidePAnel.Width += 1;
                if (sidePAnel.Width >= panelWidth)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            { 
                sidePAnel.Width -= 1;
                if (sidePAnel.Width <= 30)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }

        private void Button_click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void pnlHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton== MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

      

     

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var newForm = new Clientes(); 
            newForm.Show(); 
        }
    }
}