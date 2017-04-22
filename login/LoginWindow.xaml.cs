using System.Windows;

namespace login
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        

        public LoginWindow()
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
