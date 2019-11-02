using BusinessList;
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
    /// Interaction logic for QuarantinedWindow.xaml
    /// </summary>
    public partial class QuarantinedWindow : Window
    {
        public QuarantinedWindow(List<Links> linksList)
        {

            InitializeComponent();

            //loops until counter is the same length as the number of links in the linksList object
            for (int counter = 0; counter < linksList.Count; counter++)
            {
                //extracting each link each loop to a var so they can be added to a list box
                var currentLink = linksList[counter];
                string strlink = currentLink.link + "\n";

                //adding links to the list box
                quarantinedLinksListBox.Items.Add(strlink);
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            //closes this window;
            this.Close();
        }
    }
}
