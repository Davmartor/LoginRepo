using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace login
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void botonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void botonAceptar_Click(object sender, RoutedEventArgs e)
        {
            string user = textBox.Text.ToLower();
            string pass = passwordBox.Password;

            if (ControlUsuario.Instance.LoginUser(user,pass))
            {
                this.Hide();
                ventana2 ventana2 = new ventana2();
                ventana2.Show();
            }
            else
            {
                MessageBox.Show("error de usuario o contraseña");
            }
        }

       
    }
}
