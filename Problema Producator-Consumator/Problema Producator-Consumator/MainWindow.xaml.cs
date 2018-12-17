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

namespace Problema_Producator_Consumator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] vector;
        int n = 0;
        int max = 5;
        int numar;

        public MainWindow()
        {
            InitializeComponent();
            vector = new int[n];
        }

        private void addElement(int element)
        {
            int[] aux = new int[n + 1];
            for (int i = 0; i < n; i++)
                aux[i] = vector[i];
            aux[n] = element;
            vector = new int[aux.Length];
            for (int i = 0; i < aux.Length; i++)
                vector[i] = aux[i];
            n++;
        }

        private void tryToAdd(int element)
        {
            if (n < max)
                addElement(element);
            else
            {
                MessageBox.Show($"Error! You have reach the maximum number of elements!");
            }
        }

        private void deleteElement()
        {
            int[] aux = new int[n - 1];
            for (int i = 0; i < n - 1; i++)
                aux[i] = vector[i];
            vector = new int[aux.Length];
            for (int i = 0; i < aux.Length; i++)
                vector[i] = aux[i];
            n--;
        }

        private void tryToDelete()
        {
            if (n > 0)
                deleteElement();
            else
            {
                MessageBox.Show($"Error! You have 0 elements in vector!");
            }
        }

        private void showVector()
        {
            VectorTextBlock.Text = "";
            for (int i = 0; i < vector.Length; i++)
                VectorTextBlock.Text += vector[i] + " ";
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            numar = int.Parse(NumberTextBox.Text);
            await Task.Run(() =>
            {
                tryToAdd(numar);
            });
            showVector();
            StatusTextBlock.Text = $"Succes! You added {numar} in vector!";
            StatusTextBlock.Foreground = new SolidColorBrush(Colors.Green);
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                tryToDelete();
            });
            showVector();
            StatusTextBlock.Text = "Succes! You deleted last number from vector!";
            StatusTextBlock.Foreground = new SolidColorBrush(Colors.Green);
        }

        private void SetMaxButton_Click(object sender, RoutedEventArgs e)
        {
            if (n == 0)
            {
                max = int.Parse(NumberOfElementsInVectorTextBox.Text);
                StatusTextBlock.Text = $"Succes! You have set the maximum number of elements to {max}!";
                StatusTextBlock.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                StatusTextBlock.Text = "You can not set the number of elements only when you have 0 elements!";
                StatusTextBlock.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
