using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.Xaml;


using static System.Net.Mime.MediaTypeNames;
using System.Collections.ObjectModel;
using System.IO;



namespace tema1mvp
{
    
    public partial class MainWindow : Window
    {
        List<ImageItem> imagePaths;
        ImageItem selectedImage;
        public MainWindow()
        {
            InitializeComponent();
            InitializeImage();
            DataContext = this; // setați DataContext-ul ferestrei la sine

            string filePath = @"C:\Users\nutaa\Desktop\Facultate semestrul 2\mvlp\tema1mvp\tema1mvp\users.txt";
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].Trim();
                    if (i % 2 == 0) // dacă linia este numele de utilizator
                    {
                        string username = line;
                        string imagePath = "";
                        if (i + 1 < lines.Length) // dacă următoarea linie există
                        {
                            imagePath = lines[i + 1].Trim();
                        }
                        User user = new User(username, imagePath);
                        Users.Add(user);
                    }
                }
            }
            InitializeImage();
            ImageListBox.ItemsSource = imagePaths;
        }

        public static ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
        public static void UpdateProfilesFile()
        {
            string filePath = @"C:\Users\nutaa\Desktop\Facultate semestrul 2\mvlp\tema1mvp\tema1mvp\users.txt";
            File.WriteAllText(filePath, "");
            foreach (User user in Users)
            {
                string profileData = user.Username + "\n" + user.avatar +"\n";
                File.AppendAllText(filePath, profileData);
            }
        }

        public void InitializeImage()
        {
            this.imagePaths = new List<ImageItem>();
            string basePath = @"C:\Users\nutaa\Desktop\Facultate semestrul 2\mvlp\tema1mvp\"; // Acesta este directorul unde se află imaginile tale
            int numberOfImages = 8;

            for (int i = 1; i <= numberOfImages; i++)
            {
                string imagePath = basePath + "download" + i + ".jpg";
                imagePaths.Add(new ImageItem(imagePath));
            }
        }

       
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu playWindow = new MainMenu();
            playWindow.Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NewUserButton_Click_1(object sender, RoutedEventArgs e)
        {
            //string username = usernameTextBox.Text;// obțineți textul introdus în TextBox
            //User newUser = new User(username); // creați un nou utilizator cu acest nume
            //Users.Add(newUser); // adăugați noul utilizator la colecția de utilizatori
            //UpdateProfilesFile();   
            //usernameTextBox.Text = ""; // curățați TextBox-ul pentru a permite introducerea unui nou utilizator

            // get the username from the text box
            string username = usernameTextBox.Text;

            // get the selected image from the list box
            ImageItem selectedImage = ImageListBox.SelectedItem as ImageItem;

            // create a new user object with the given username and avatar
            User newUser = new User(username, selectedImage.ImagePath);

            // add the user to the list
            Users.Add(newUser);

            // clear the text box and list box selection
            usernameTextBox.Text = "";
            ImageListBox.SelectedItem = null;

            // update the user list display
            UpdateProfilesFile();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Verificați dacă utilizatorul a selectat un element în ListBox
            if (usersListBox.SelectedItem != null)
            {
                // Obțineți utilizatorul selectat
                User selectedUser = (User)usersListBox.SelectedItem;

                // Eliminați utilizatorul selectat din colecția de utilizatori
                Users.Remove(selectedUser);

                // Actualizați fișierul cu profiluri
                UpdateProfilesFile();

                // Resetați selecția ListBox
                usersListBox.SelectedItem = null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}