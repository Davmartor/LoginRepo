using System.Windows;


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

       

        private void addCombat_Click(object sender, RoutedEventArgs e)
        {
            AddCombat ad = new AddCombat();
            ad.Show();
        }
    }
}
