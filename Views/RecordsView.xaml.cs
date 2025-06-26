using MVVM.BD;
using System.Windows;
using System.Windows.Controls;

namespace MVVM.Views
{
    /// <summary>
    /// Lógica de interacción para RecordsView.xaml
    /// </summary>
    public partial class RecordsView : UserControl
    {
        public RecordsView()
        {
            InitializeComponent();

            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                MVVM.BD.BD bd = new MVVM.BD.BD();
                var usuarios = bd.Get();

                if (usuarios == null)
                {
                    MessageBox.Show("La lista de usuarios es null.");
                    return;
                }

                if (usuarios.Count == 0)
                {
                    MessageBox.Show("No hay usuarios en la lista.");
                }
                else
                {
                    MessageBox.Show($"Se cargaron {usuarios.Count} usuarios.");
                    dataGridUsuarios.ItemsSource = usuarios;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }
    }
}
