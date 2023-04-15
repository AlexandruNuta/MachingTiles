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
using System.IO;

namespace tema1mvp
{
    /// <summary>
    /// Interaction logic for CustomWindow.xaml
    /// </summary>
    public partial class CustomWindow : Window
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public CustomWindow()
        {
            InitializeComponent();
        }

        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Rows = int.Parse(RowsTextBox.Text);
            Columns = int.Parse(ColumnsTextBox.Text);
            Console.WriteLine(Rows);
            Console.WriteLine(Columns);
            string path = @"C:\Users\nutaa\Desktop\Facultate semestrul 2\mvlp\tema1mvp\tema1mvp\Matrix.txt";
            File.WriteAllText(path, "");
            File.AppendAllText(path, RowsTextBox.Text + Environment.NewLine);
            File.AppendAllText(path, ColumnsTextBox.Text + Environment.NewLine);
            MessageBox.Show("S a salvat cu succes");
        }
    }
}
