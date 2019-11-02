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

namespace Euston_Leisure_Messaging__ELM_
{
    /// <summary>
    /// Interaction logic for Email.xaml
    /// </summary>
    public partial class Email : Window
    {
        public Email()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //module call
            emailVal();

        }



        //validates that the user has entered a valid type of email address
        private void emailVal()
        {

            /*compares the emails the user has entered
             * to see if they are in correct email format */
            Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

            //if email not entered in correct format, user will be asked to re-enter both emails
            if(!reg.IsMatch(email_Input.Text) || !reg.IsMatch(recEmail_Input.Text))
            {
                MessageBox.Show("Please enter a valid email address");
                //input boxes are cleared
                email_Input.Clear();
                recEmail_Input.Clear();
                subjectInput.Clear();
                //returned to re-enter values
                return;
            }
            else
            {
                string emailSubject = subjectInput.Text;
                int maxlength = 20;


                if (emailSubject.Length > maxlength)
                {
                    MessageBox.Show("Please enter a subject smaller than 20 characters");
                    subjectInput.Clear();
                    return;
                }
                else
                {
                    string selectedEmailType;
                    selectedEmailType = ((ComboBoxItem)comboOptions.SelectedItem).Content.ToString();


                    //test to see if correct value held
                    //MessageBox.Show(selectedEmailType);

                    if(selectedEmailType == "S.I.R")
                    {
                        //opens new dialog for if message type is SIR
                        EmailSIR emailWinSIR = new EmailSIR();
                        emailWinSIR.ShowDialog();
                    

                        this.Close();
                    }
                    else
                    {
                        this.Close();
                    }


                }
            }

            
            



        }


    }
}
