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
using static Euston_Leisure_Messaging__ELM_.MainWindow;

namespace Euston_Leisure_Messaging__ELM_
{
    /// <summary>
    /// Interaction logic for EmailSIR.xaml
    /// </summary>
    public partial class EmailSIR : Window
    {

        public EmailSIR()
        {
            InitializeComponent();

            //added in this part of code so the date is displayed in the last box when the window opens
            //sets dt to current date
            DateTime dt = DateTime.Now.Date;
            //converts dt time to string
            dt.ToString();
            //adds dt to listbox
            DateTimeBox.Items.Add("S.I.R:   " + dt.ToShortDateString());

            string[] lineOfContents = File.ReadAllLines(@"J:\Uni\Year 3\Software Development\Coursework\OFFICIAL\Euston Leisure Messaging (ELM)\comboboxitems.txt");

            foreach(var line in lineOfContents)
            {
                sportsCentreCodeBox.Items.Add(line);
            }


           

        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {

            //if combo box isn't null, means user has selected a value so we can close window
            if(sportsCentreCodeBox.SelectedItem != null)
            {

                string sportsCentreCode = sportsCentreCodeBox.SelectedItem.ToString();

                //need to store the direct value of the combo box to prevent it from storing "System.Windows.Controls.ComboBoxItem: Bomb Threat";
                var item = (ComboBoxItem)sirOptions.SelectedItem;
                string incident = (string)item.Content;

                /*writes the sports centre code to txt file
                 *1) once emailSIR was closed or hidden sportsCentreCodeBox.SelectedItem became null once again
                 *2) passing parameters also had the above issue so easier to write to file then read it in again later */
                File.WriteAllText(@"J:\Uni\Year 3\Software Development\Coursework\OFFICIAL\Euston Leisure Messaging (ELM)\codeBoxSelection.txt", sportsCentreCodeBox.SelectedItem.ToString());
                File.WriteAllText(@"J:\Uni\Year 3\Software Development\Coursework\OFFICIAL\Euston Leisure Messaging (ELM)\incidentReport.txt", incident);
                this.Hide();


            }
            else
            {
                //tell user to selected a sports centre code
                MessageBox.Show("Please select a sports centre code");
            }



        }


        private void BtnAddNewSC_Click(object sender, RoutedEventArgs e)
        {
            //stores sports centre code input
            string sportsCentreCode = newSCcode.Text;

            /*if the input is equal to 10 then we have a perfect input size so enter if
             * if the size is smaller than 10 this means we will have null vals which will
             * crash the program when trying to assign positions to chars */
                if (sportsCentreCode.Length == 10)
            {
                char number1 = sportsCentreCode[0];
                char number2 = sportsCentreCode[1];

                char dash1 = sportsCentreCode[2];
                char dashtype = '-';

                char number3 = sportsCentreCode[3];
                char number4 = sportsCentreCode[4];
                char number5 = sportsCentreCode[5];

                char dash2 = sportsCentreCode[6];


                char number6 = sportsCentreCode[7];
                char number7 = sportsCentreCode[8];
                char number8 = sportsCentreCode[9];

                //if length is bigger than 10 or any char is a letter then we have invalid input
                while (sportsCentreCode.Length > 10 | char.IsLetter(number1) | char.IsLetter(number2) | dash1 != dashtype | char.IsLetter(number3) | char.IsLetter(number4) | char.IsLetter(number5) | dash2 != dashtype | char.IsLetter(number6) | char.IsLetter(number7) | char.IsLetter(number8))
                {
                    //return the user to re-enter correctly
                    MessageBox.Show("Please ensure your sports centre code is smaller than 9 chars and in this format 'NN-NN-NNN including dashes'");
                    return;
                }

                sportsCentreCodeBox.Items.Add(sportsCentreCode);
                File.AppendAllText(@"J:\Uni\Year 3\Software Development\Coursework\OFFICIAL\Euston Leisure Messaging (ELM)\comboboxitems.txt", sportsCentreCode);
            }
        }

    }
}
