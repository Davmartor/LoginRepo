using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace login
{
    /// <summary>
    /// Lógica de interacción para ventana2.xaml
    /// </summary>
    public partial class ventana2 : Window
    {
        
        public ventana2()
        {
            InitializeComponent();

            userName.Content = "¡Hola " + ControlUsuario.Instance.Usuario + "!";



            
            clasificación.ItemsSource = ConectorBD.Instance.getDefaulView(); 

                
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
