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

namespace Euston_Leisure_Messaging__ELM_
{
    /// <summary>
    /// Interaction logic for TweetWindow.xaml
    /// </summary>
    public partial class TweetWindow : Window
    {
        public TweetWindow()
        {
            InitializeComponent();
        }


        private void BtnAddUsername_Click(object sender, RoutedEventArgs e)
        {
            string check = twitterUserNameInput.Text;
            string checkIndex = check.Substring(0, 1);
            //checks that the user has enter the id in the correct format
            if(!checkIndex.Contains("@") | check.Length > 15 | check.Length < 1)
            {
                //returns user to re-enter input in correct format
                MessageBox.Show("Please enter in correct format: \n\n1) Starts with @ sign \n2)Max size of 15 chars \n3)Minimum size of 2 chars");
                return;
            }

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            //close
            this.Close();
        }
    }
}
