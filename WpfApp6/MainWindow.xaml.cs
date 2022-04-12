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

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum Abit_Properties
    {
        Russian = 1, Math = 2, Physics = 4, English = 6, Informatika = 8, Literature = 10, Germany = 12
    }
    public partial class MainWindow : Window
    {
        private Abiturient abiturient;
        public MainWindow()
        {
            InitializeComponent();
            foreach (string str in Enum.GetNames(typeof(Abit_Properties)))
            {
                CheckBox checkBox = new CheckBox
                {
                    Content = str,
                    MaxHeight = 30,
                    IsChecked = false,
                    Margin = new Thickness(10)
                };
                checkBox.Checked += checkBox_checked;
                Patterns.Children.Add(checkBox);
            }
        }

        private void checkBox_checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            Abit_Properties properties = (Abit_Properties)Enum.Parse(typeof(Abit_Properties),
                                        checkBox.Content.ToString());
            abiturient.Pattern = properties;
            Result.Text = "";
            foreach (string str in abiturient.CandsHavePet())
            {
                Result.Text += str + "\n";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = "";
            int n = 15;
            abiturient = new Abiturient(n);
            abiturient.FormCanda();
            Abit_Properties[] cand = abiturient.GetCands();
            for (int i = 0; i < Patterns.Children.Count; i++)
            {
                (Patterns.Children[i] as CheckBox).IsChecked = false;
            }
            string[] strCand = abiturient.GetStrCands();
            for (int i = 0; i < n; i++)
            {
                Result.Text += "Свойства кандидата " + (i + 1) + "-" + cand[i] + "\n";
                Result.Text += strCand[i] + '\n';
            }
        }
    }
}
