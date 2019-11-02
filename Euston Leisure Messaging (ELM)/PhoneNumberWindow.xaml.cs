using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessList;

namespace Euston_Leisure_Messaging__ELM_
{
    /// <summary>
    /// Interaction logic for PhoneNumberWindow.xaml
    /// </summary>
    public partial class PhoneNumberWindow : Window
    {
        public PhoneNumberWindow()
        {
            InitializeComponent();
        }


       
        public void PhoneNumberBtn_Click(object sender, RoutedEventArgs e)
        {
            string number = phoneNumberInput.Text;

            //checks number is entered correctly
            if (number.Length > 15 | number == null | number == "")
            {
                MessageBox.Show("Number must be smaller than 15 characters");
                phoneNumberInput.Clear();
                return;
            }


            /*insures the user only inputs numbers so user cant enter
             * numbers + characters
             * characters */
            Regex reg = new Regex(@"^[\d-]+$");
            if(!reg.IsMatch(phoneNumberInput.Text))
            {
                MessageBox.Show("Please only enter numbers");
                phoneNumberInput.Clear();
                return;
            }
            else
            {
                //close window
                this.Close();
            }

      


        }

    }
}
