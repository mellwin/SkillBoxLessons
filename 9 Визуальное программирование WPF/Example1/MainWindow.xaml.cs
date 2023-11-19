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

namespace Example1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnParse(object sender, RoutedEventArgs e)
        {
            lbWords.Items.Clear();

            List<string> words = GetWordsListFromText(txbInputText1.Text);

            foreach (var w in words)
            {
                lbWords.Items.Add(w); 
            }
        }

        private void BtnReverse(object sender, RoutedEventArgs e)
        {
            List<string> words = GetWordsListFromText(txbInputText2.Text);

            lblOutputReverseText.Content = GetReverseTextFromList(words);
        }

        public static List<string> GetWordsListFromText(string input)
        {
            char sym = ' ';
            List<string> wordsList = input.Split(new char[] { sym }, StringSplitOptions.RemoveEmptyEntries).ToList();

            return wordsList;
        }

        public static string GetReverseTextFromList(List<string> input)
        {
            string newText = "";
            for (int i = input.Count - 1; i >= 0; i--)
            {
                newText += input[i] + " ";
            }

            return newText;
        }

    }
}
