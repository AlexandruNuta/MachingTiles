using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace tema1mvp
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }


        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.Show();
        }

        private void OpenGame_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SaveGame_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            // Cod pentru salvarea statisticii jocurilor
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            // Cod pentru iesirea din fereastra curenta si revenirea la ecranul de login
        }

        private void Standard_Click(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\nutaa\Desktop\Facultate semestrul 2\mvlp\tema1mvp\tema1mvp\Matrix.txt";
            File.WriteAllText(path, "");
            File.AppendAllText(path,5 + Environment.NewLine);
            File.AppendAllText(path,5 + Environment.NewLine);
            MessageBox.Show("S a salvat cu succes");
        }

        private void Custom_Click(object sender, RoutedEventArgs e)
        {
            CustomWindow customWindow = new CustomWindow();
            if (customWindow.ShowDialog() == true)
            {
                int rows = customWindow.Rows;
                int columns = customWindow.Columns;
                // faceți ceva cu valorile rows și columns
            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            // Cod pentru afisarea ferestrei "About"
            var aboutWindow = new Window { Title = "About" };
            var label = new Label { Content = "Nume: [nume]\nGrupa: [grupa]\nSpecializare: [specializare]" };
            aboutWindow.Content = label;
            aboutWindow.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
