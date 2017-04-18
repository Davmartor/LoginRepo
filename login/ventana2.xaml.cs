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

            ConectorBD.Instance.Conectar();

            string query = @"SELECT nombre,id_combats,id_victories,id_ko,best_assault,best_time,rival  
                            FROM clasificacion_boxeadores";
            
            MySqlCommand consulta = new MySqlCommand(query, ConectorBD.Instance.conn);

            MySqlDataAdapter myAdapter = new MySqlDataAdapter();

            myAdapter.SelectCommand = consulta;

            DataTable dTable = new DataTable();

            myAdapter.Fill(dTable);

            clasificación.ItemsSource = dTable.DefaultView; 

            ConectorBD.Instance.CloseConnection();
                
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
