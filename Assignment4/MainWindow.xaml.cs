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

namespace Assignment4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string>salman = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if(pla.Text != "")
            {
                if(!salman.Contains(pla.Text))
                {
                    salman.Add(pla.Text);
                    plas.ItemsSource = null;
                    plas.ItemsSource = salman;
                    pla.Text = "";
                    MessageBox.Show("Player added");
                }
                else
                {
                    MessageBox.Show("App sy iltmaas hai k koi aur player add ki jiye");
                }
            }
            else
            {
                MessageBox.Show("Enter name of the player");
            }
        }

        private void re_Click(object sender, RoutedEventArgs e)
        {
            salman.RemoveAt(plas.SelectedIndex);
            plas.ItemsSource = null;
            plas.ItemsSource = salman;
            MessageBox.Show(" mubarak ho player remove ho chuka ha");
        }
    }
}