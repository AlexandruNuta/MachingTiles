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
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.Data.Common;


namespace tema1mvp
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public int rows;
        public int columns;
        public int[,] buttonGrid;
        List<string> imagePaths;
        Dictionary<string, List<Tuple<int, int>>> imagePairs = new Dictionary<string, List<Tuple<int, int>>>();
        public GameWindow()
        {
            InitializeComponent();
            DataContext = this;
            InitializeMatrix();
            GridCreation();
            InitializeImage();
            InitializePairs();
            int numberOfRounds = 0;
        }
        public bool VerifyMatrix()
        {
            bool allDisabled = true;
            foreach (Button button in MyGrid.Children)
            {
                if (button.IsEnabled)
                {
                    allDisabled = false;
                    break;
                }
            }
            return allDisabled;
        }
        public void ButtonActivation()
        {
            foreach (Button button in MyGrid.Children)
            {
                button.IsEnabled = true;
            }
        }
        public void InitializeMatrix()
        {
            string path = @"C:\Users\nutaa\Desktop\Facultate semestrul 2\mvlp\tema1mvp\tema1mvp\Matrix.txt";
            string[] lines = File.ReadAllLines(path);
            rows = int.Parse(lines[0]);
            columns = int.Parse(lines[1]);
            Random rnd = new Random();
            buttonGrid = new int[rows, columns];
            Dictionary<int, int> valueOccurrences = new Dictionary<int, int>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int key = (int)(rnd.NextDouble() * ((rows * columns)));
                    while (valueOccurrences.ContainsKey(key) && valueOccurrences[key] >= 1)
                    {
                        key = (int)(rnd.NextDouble() * ((rows * columns)));
                    }
                    buttonGrid[i, j] = key;
                    if (!valueOccurrences.ContainsKey(key))
                    {
                        valueOccurrences.Add(key, 1);
                    }
                    else
                    {
                        valueOccurrences[key]++;
                    }
                }
            }
        }
        public void InitializeImage()
        {
            this.imagePaths = new List<string>();
            string basePath = @"C:\Users\nutaa\Desktop\Facultate semestrul 2\mvlp\tema1mvp\"; // Acesta este directorul unde se află imaginile tale
            int numberOfImages = (rows * columns+1) / 2;

            for (int i = 1; i <= numberOfImages; i++)
            {
                string imagePath = basePath + "download" + i + ".jpg";
                imagePaths.Add(imagePath);
            }
        }

        public void InitializePairs()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    string imagePath = imagePaths[buttonGrid[i, j] / 2];
                    Tuple<int, int> cell = new Tuple<int, int>(i, j);

                    if (imagePairs.ContainsKey(imagePath))
                    {
                        imagePairs[imagePath].Add(cell);
                    }
                    else
                    {
                        List<Tuple<int, int>> cellList = new List<Tuple<int, int>>();
                        cellList.Add(cell);
                        imagePairs.Add(imagePath, cellList);
                    }
                }
            }
        }

        public void GridCreation()
        {
            Grid grid = new Grid();
            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int j = 0; j < columns; j++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Button button = new Button();
                    grid.Children.Add(button);
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    button.Click += Piece_Click;
                }
            }
            MyGrid.Children.Add(grid);
        }

        int selectedRow1 = -1;
        int selectedColumn1 = -1;
        string imagePath1;
        int selectedRow2 = -1;
        int selectedColumn2 = -1;
        Button Pbutton;
        private void Piece_Click(object sender, RoutedEventArgs e)
        {
            // Dictionary<string, List<Tuple<int, int>>> imagePairs = new Dictionary<string, List<Tuple<int, int>>>();

            Button clickedButton = sender as Button;
            int row = Grid.GetRow(clickedButton);
            int col = Grid.GetColumn(clickedButton);

            string imagePath = imagePaths[buttonGrid[row, col] / 2];
            ImageBrush imageBrush = new ImageBrush(new BitmapImage(new Uri(imagePath, UriKind.Relative)));
            clickedButton.Background = imageBrush;

            if (selectedRow1 == -1 && selectedColumn1 == -1)
            {
                // first cell selected
                selectedRow1 = row;
                selectedColumn1 = col;
                imagePath1 = imagePath;
                Pbutton = clickedButton;
            }
            else if (selectedRow2 == -1 && selectedColumn2 == -1)
            {
                // second cell selected
                selectedRow2 = row;
                selectedColumn2 = col;
                // compare values
                List<Tuple<int, int>> tuples1 = imagePairs[imagePath1];
                Tuple<int, int> tuple1 = new Tuple<int, int>(selectedRow1, selectedColumn1);
                Tuple<int, int> tuple2 = new Tuple<int, int>(selectedRow2, selectedColumn2);
                if (tuples1.Contains(tuple1) && tuples1.Contains(tuple2))
                {
                    MessageBox.Show("Pair found");
                    // cells match
                    // display image or do something else to indicate match
                    Pbutton.IsEnabled = false;
                    clickedButton.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("Pair  not found");
                    // cells do not match
                    // hide cells or do something else to indicate no match
                    clickedButton.Background = Brushes.LightGray;
                    //Button clickedbutton1 = new Button[selectedRow1,selectedColumn1];
                    Pbutton.Background = Brushes.LightGray;
                }

                // reset selections
                selectedRow1 = -1;
                selectedColumn1 = -1;
                selectedRow2 = -1;
                selectedColumn2 = -1;
            }


        }

    }
}
