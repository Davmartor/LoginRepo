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
using System.Windows.Shapes;

namespace login
{
    /// <summary>
    /// Lógica de interacción para AddCombat.xaml
    /// </summary>
    /// 


    public partial class AddCombat : Window
    {
    private Dictionary<string, string> Boxeadores;
        private bool isEditable;

        public AddCombat()
        {
            InitializeComponent();

            isEditable = true;

            Boxeadores = ConectorBD.Instance.rellenarBoxeadores();

            InitializeComboBoxers();
        }

        private void InitializeComboBoxers()
        {
            RellenarComboBoxeador(boxerLocal);
            RellenarComboBoxeador(boxerRival);
        }

        private void boxerLocal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AnularBoxeadorEnComboBoxContrario(boxerLocal, boxerRival);

        }
        private void boxerRival_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AnularBoxeadorEnComboBoxContrario(boxerRival, boxerLocal);
        }

        private void AnularBoxeadorEnComboBoxContrario(ComboBox seleccionado, ComboBox contrario)
        {
            if (this.isEditable)
            {
                string name = seleccionado.SelectedItem.ToString();
                string nameContrario;


                if (contrario.SelectedItem != null)
                {
                    nameContrario = contrario.SelectedItem.ToString();

                }else
                {
                    nameContrario = "";
                }
                
                this.isEditable = false;
                
                RellenarComboBoxeador(contrario, name);
                contrario.SelectedItem = nameContrario;

                this.isEditable = true;
            }
        }

        private void RellenarComboBoxeador(ComboBox c)
        {
            this.RellenarComboBoxeador(c, String.Empty);
                
        }

        private void RellenarComboBoxeador(ComboBox c, string nombreBoxeador)
        {
            c.Items.Clear();
            foreach(string b in Boxeadores.Keys)
            {
                if (!b.Equals(nombreBoxeador))
                {
                    c.Items.Add(b);
                }
            }

        }
    }
}
