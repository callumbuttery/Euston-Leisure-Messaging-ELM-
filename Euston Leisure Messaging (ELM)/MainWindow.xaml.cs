using BusinessList;
using Datalayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace Euston_Leisure_Messaging__ELM_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //obj declaration 
        private static Quarantined_Links store;
        private static EmailList emailStore;
        private static SmsList smsStore;
        private static TweetList tweetStore;

        string messageHeader = "";
        string messageBody = "";
      

        /*var used to prevent relooping
         * i.e. if the user has correctly entered the subject correctly
         * and all other conditions e.g. selected a S.I.R report email type
         * but hasn't entered the message body correctly e.g. bigger than 1028 characters in size.
         * As this var is set to true it will stop the software from re-looping to select the S.I.R report
         * again just because the message body is wrong.
         * */
        bool SubjectCheck = false;

        //all vars for email information
        string emails = "";
        string recEmail = "";
        string subject = "";
        string selectedEmailType = "";
        string sportsCentreCode = "";
        string natureOfSIR = "";
        string dt;
        string messageType = "";


        public MainWindow()
        {
            InitializeComponent();
            //new objects that can be referenced to store 
            store = new Quarantined_Links();
            emailStore = new EmailList();
            smsStore = new SmsList();
            tweetStore = new TweetList();
        }




        //Code connects to add email button
        private void AddMessage_Click(object sender, RoutedEventArgs e)
        {

            messageBody = messageBodyInput.Text;
            messageHeader = headerInput.Text;

            if (messageHeader.Length != 12 || messageBody == null)
            {
                MessageBox.Show("Please ensure your head length is 12 chars long and your message body isn't null");
                return;
            }

            //used to validate that the user has enter text into both the header and message body
            bool check = inputValidation();

            if(check == true)
            {

                while (messageBody == "" & messageHeader == "")
                {
                    InputValWin win1 = new InputValWin();
                    win1.ShowDialog();

                    messageHeader = win1.headerBox.Text;
                    messageBody = win1.bodyInput.Text;

                    inputValidation();
                }
            }

          
                //opens new window to get users email address
                Email emailWin = new Email();
                EmailSIR emailWinSIR = new EmailSIR();

                if (SubjectCheck == false)
                {
                     emailWin.ShowDialog();

                    //holds the vals entered in the email window
                    emails = emailWin.email_Input.Text;
                    recEmail = emailWin.recEmail_Input.Text;
                    selectedEmailType = ((ComboBoxItem)emailWin.comboOptions.SelectedItem).Content.ToString();
                    subject = emailWin.subjectInput.Text;

                    //all info from emailWinSIR window
                    sportsCentreCode = emailWinSIR.sportsCentreCodeBox.SelectedItem.ToString();
                    emailWinSIR.Close();
                    natureOfSIR = ((ComboBoxItem)emailWinSIR.sirOptions.SelectedItem).Content.ToString();
                    dt = DateTime.Now.ToShortDateString();





                    //tests to see if values are being held properly
                    //MessageBox.Show(email);
                    //MessageBox.Show(recEmail);
                    //MessageBox.Show(subject);


                    
                    messageType = "email";
                    headerChecker(messageHeader, messageType);
                    SubjectCheck = true;
                }

                messageBody = messageBodyInput.Text;
                //calls on method that checks the message the user wants to send it correct
                messageBodyChecker(messageBody, messageType);
            
            
        }





        //code connects to add tweet button
        private void AddTweet_Click(object sender, RoutedEventArgs e)
        {

            messageBody = messageBodyInput.Text;
            messageHeader = headerInput.Text;

            if (messageHeader.Length != 12 || messageBody == null)
            {
                MessageBox.Show("Please ensure your head length is 12 chars long and your message body isn't null");
                return;
            }

            //used to validate that the user has enter text into both the header and message body
            bool check = inputValidation();

            if (check == true)
            {
               
                while (messageBody == "" & messageHeader == "")
                {
                    InputValWin win1 = new InputValWin();
                    win1.ShowDialog();

                    messageHeader = win1.headerBox.Text;
                    messageBody = win1.bodyInput.Text;

                    inputValidation();
                }
            }

            //used to store the users twitter username

            string messageType = "Tweet";




            if (SubjectCheck == false)
            {


                //declares that the message type is a tweet
                

                //checks header information entered by the user
                headerChecker(messageHeader, messageType);
                SubjectCheck = true;
            }

            messageBody = messageBodyInput.Text;
            //calls on method that checks the message the user wants to send it correct
            messageBodyChecker(messageBody, messageType);

        }





        //code connects to add sms button
        private void AddSms_Click(object sender, RoutedEventArgs e)
        {

            messageBody = messageBodyInput.Text;
            messageHeader = headerInput.Text;

            if(messageHeader.Length != 12 || messageBody == null)
            {
                MessageBox.Show("Please ensure your head length is 12 chars long and your message body isn't null");
                return;
            }

            //used to validate that the user has enter text into both the header and message body
            bool check = inputValidation();

            if (check == true)
            {

                while (messageBody == "" & messageHeader == "")
                {
                    InputValWin win1 = new InputValWin();
                    win1.ShowDialog();

                    messageHeader = win1.headerBox.Text;
                    messageBody = win1.bodyInput.Text;

                    inputValidation();
                }
            }


            string messageType = "sms";

            if (SubjectCheck == false)
            {
                //sets messageHeader to the users input for messageHeader
                headerChecker(messageHeader, messageType);
                SubjectCheck = true;

               
            }

            //calls on method that checks the message the user wants to send it correct
            messageBodyChecker(messageBody, messageType);
        }






        //checks the header message entered by the user follows the requirements
        private void headerChecker(string messageHeader, string messageType)
        {
            try
            {
                
                //checks text has been entered
                if (messageHeader == "" || messageHeader == null || messageHeader.Length != 12)
                {
                    //Returns user to re-enter a proper message header with the correct requirements
                    MessageBox.Show("Please enter a message header e.g. set123456789");
                    messageHeader = null;
                    return;
                }
                else
                {
                    //counter for loop
                    int counter = 0;
                    //following chars used to store the first 3 characters of the users input
                    char posone;
                    char postwo;
                    char posthree;

                    //used to check that user has entered the message header in the correct way
                    char pos4;
                    char pos5;
                    char pos6;
                    char pos7;
                    char pos8;
                    char pos9;
                    char pos10;
                    char pos11;
                    char pos12;

                    //sets the users input to lower case to prevent future errors
                    messageHeader = messageHeader.ToLower();

                    //used to compare the users input  to see if they have entered correct format
                    char charone = 's';
                    char chartwo = 'e';
                    char charthree = 't';

                    //stores all message header values entered by the user in positions 1 -> 3
                    //used to check that user has entered the message header in the correct way
                    posone = messageHeader[0];
                    postwo = messageHeader[1];
                    posthree = messageHeader[2];

                    //stores all message header values enter by the user in positions 4 -> 12
                    //used to check that user has entered the message header in the correct way
                    pos4 = messageHeader[3];
                    pos5 = messageHeader[4];
                    pos6 = messageHeader[5];
                    pos7 = messageHeader[6];
                    pos8 = messageHeader[7];
                    pos9 = messageHeader[8];
                    pos10 = messageHeader[9];
                    pos11 = messageHeader[10];
                    pos12 = messageHeader[11];
                  

                    //comparsion
                    if (posone == charone && postwo == chartwo && posthree == charthree)
                    {
                        if(char.IsDigit(pos4) && char.IsDigit(pos5) && char.IsDigit(pos6) && char.IsDigit(pos7) && char.IsDigit(pos8) && char.IsDigit(pos9) && char.IsDigit(pos10) && char.IsDigit(pos11) && char.IsDigit(pos12))
                        {
                           
                        }
                    }
                    else
                    {
                        //returns users as they haven't entered correctly 
                        MessageBox.Show("Please enter a valid message header e.g. set123456789");
                        return;
                    }

                }
            }

            catch
            {
                //prevents crash due to failing to store the header
                MessageBox.Show("Failed to store header");
                messageHeader = null;
                //restarts app to handle crash
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
                return;
            }
        }




        /*validates different conditions for the messages the users has entered depending on the message typ
         * e.g. type = email, message max size = 1028 chars
         * e.g. type = sms, message max size = 140 cars, textspeak abbreviations expanded
         * e.g. type = tweet, textspeak abbreviations expanded, preduce trending list i.e mentions and hashtags */

        private void messageBodyChecker(string messageBody, string messageType)
        {
            

            if(messageType == "email")
            {
                int maxsize = 1028;

                //checks the message body isn't over 1028 characters
                if(messageBody.Length > maxsize)
                {
                    MessageBox.Show("Please enter a message size that is less than 1028 characters");
                    return;
                }
                else
                {
                    //search standard email messages for urls to be Quarantined
                    var linkfinder = new Regex(@"\b(?:https?://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);

                    //put in place of link that is found in string
                    string replacement = "URL <Quarantined>";
                    //pattern regex is looking for
                    string pattern = @"\b(?:https?://|www\.)\S+\b";


                    //method used to search for abbrevations within the messagebody 
                    checkForAbbreviations(messageBody);
                   

                    //searches fo matches in the messageBody variable
                    foreach (Match ItemMatch in linkfinder.Matches(messageBody))
                    {
                        //new link object L
                        Links L = new Links();
                        

                      
                        //testing
                        //MessageBox.Show(ItemMatch.Value);

                        string match = ItemMatch.Value;
                        L.link = match;

                        //searches message body for links, looks for links using pattern variable, replaces links with replacement variable
                        messageBody = Regex.Replace(messageBody, pattern, replacement);

                        //test
                        //MessageBox.Show(messageBody);

                        //adds new link to quaratined list object
                        store.add(L);

                        string strResult = JsonConvert.SerializeObject(L);
                        File.WriteAllText(@"J:\Uni\Year 3\Software Development\Coursework\OFFICIAL\Euston Leisure Messaging (ELM)\quarantinedInfo.json", strResult);

                    }

                    //new email object to allow me to add all information about the emails
                    Emails E = new Emails();


                    //gathering all information that has to be stored about the email 
                    E.email = emails;
                    E.recEmail = recEmail;
                    E.headerInfo = messageHeader;
                    E.messageBody = messageBody;
                    E.selectedEmailType = selectedEmailType;
                    E.emailSubject = subject;
                    E.sportsCentreCode = sportsCentreCode;

                    if(selectedEmailType == "Standard Email Message")
                    {
                        natureOfSIR = "N/A";
                    }

                    E.natureOfSIR = natureOfSIR;
                    E.dateTime = dt;

                    //stores emails through object E
                    emailStore.add(E);

                    //sets subject check to false so users can enter another email
                    SubjectCheck = false;

                    //adds all email information to list box for user to see
                    gatherEmailsListBox.Items.Add("\nSender email: " + emails);
                    gatherEmailsListBox.Items.Add("Email Recipent: " + recEmail);
                    gatherEmailsListBox.Items.Add("Email Message header: " + messageHeader);
                    gatherEmailsListBox.Items.Add("Email Message body : " + messageBody);
                    gatherEmailsListBox.Items.Add("Email type: " + selectedEmailType);
                    gatherEmailsListBox.Items.Add("Email subject: " + subject);
                    gatherEmailsListBox.Items.Add("Sports centre code: " + sportsCentreCode);
                    gatherEmailsListBox.Items.Add("Nature of incident: " +natureOfSIR);
                    gatherEmailsListBox.Items.Add("Date: " + dt);


                    //writes email to json file
                    string strResultJSON = JsonConvert.SerializeObject(E);
                    File.AppendAllText(@"J:\Uni\Year 3\Software Development\Coursework\OFFICIAL\Euston Leisure Messaging (ELM)\emailInfo.json", strResultJSON);

                    //new text write tw
                    using (TextWriter tw = new StreamWriter(@"J:\Uni\Year 3\Software Development\Coursework\OFFICIAL\Euston Leisure Messaging (ELM)\AllInfo.txt", true))
                    {

                        //write object vars to positions in text file
                        tw.WriteLine(string.Format("\nSender Email: {0} \nEmail Recipent: {1} \nEmail Header Info: {2} \nEmail Message Body: {3} \nEmail Type: {4} \nEmail Subject: {5} \nSports Centre Code: {6} \nNature of incident: {7} \nDate: {8}\n", E.email, E.recEmail, E.headerInfo, E.messageBody, E.selectedEmailType, E.emailSubject, E.sportsCentreCode, E.natureOfSIR, E.dateTime));


                    }

                    //clear inputs
                    messageBodyInput.Clear();
                    headerInput.Clear();




                }
            }

           if(messageType == "sms")
            {
                int maxsize = 140;
                PhoneNumberWindow phoneWin = new PhoneNumberWindow();

                //checks messagebody isn't over the maximum character limit
                if (messageBody.Length > maxsize)
                {
                    MessageBox.Show("SMS messages have a character limit of 140, please remove characters");
                    return;
                }
                else
                {
                    
                    //checks for any abbverations within the message body
                    messageBody = checkForAbbreviations(messageBody);

                    //show phonewin
                    phoneWin.ShowDialog();


                    //stores data from the phone number window
                    string areaCode = ((ComboBoxItem)phoneWin.areaCodeBox.SelectedItem).Content.ToString();
                    string phoneNumber = "";
                    phoneNumber = phoneWin.phoneNumberInput.Text;


                    //create new sms object
                    Sms s = new Sms();

                    //add details to object s
                    s.areaCode = areaCode;
                    s.senderNumber = phoneNumber;
                    s.headerInfo = messageHeader;
                    s.messageBody = messageBody;

                    //store sms object
                    smsStore.add(s);

                    //subject check can now be set to false to allow other messages to be added
                    SubjectCheck = false;


                    //add to list box
                    gatherSmsListBox.Items.Add("\nArea Code: " + areaCode);
                    gatherSmsListBox.Items.Add("Phone Number: " + phoneNumber);
                    gatherSmsListBox.Items.Add("SMS message header: " + messageHeader);
                    gatherSmsListBox.Items.Add("SMS message body: " + messageBody);


                    //write to json file
                    string strResultJSON = JsonConvert.SerializeObject(s);
                    File.AppendAllText(@"C:\Users\Callum\Desktop\Euston Leisure Messaging (ELM)\smsInfo.json", strResultJSON);



                    //new textwriter
                    using (TextWriter tw = new StreamWriter(@"J:\Uni\Year 3\Software Development\Coursework\OFFICIAL\Euston Leisure Messaging (ELM)\AllInfo.txt", true))
                    {

                        //write object vars to positions in text file
                        tw.WriteLine(string.Format("\nAreaCode: {0} \nPhone Number: {1} \nSMS Header Info: {2} \nSMS Message Body: {3}\n", s.areaCode, s.senderNumber, s.headerInfo, s.messageBody));

                    }

                    //clear inputs
                    messageBodyInput.Clear();
                    headerInput.Clear();


                }
            }



            //enters if the type of message the user wants to enter is a tweet
            if(messageType == "Tweet")
            {
                //character limit
                int maxsize = 140;

                //enters if the users input exceeds the character limit
                if (maxsize <= messageBody.Length)
                {
                    //error message
                    MessageBox.Show("Max message body size 140 characters, please remove characters");
                    return;
                }
                else
                {
                    //method used to search for abbrevations within the messagebody 
                    messageBody = checkForAbbreviations(messageBody);

                    //new instance of the tweet window
                    TweetWindow tweetWin = new TweetWindow();
                    tweetWin.ShowDialog();

                    //new tweet object
                    Tweet t = new Tweet();

                    //gathers twitter info from input boxes on 
                    string twitterID = tweetWin.twitterUserNameInput.Text;


                    t.twitterID = tweetWin.twitterUserNameInput.Text;
                    

                    //assign t object vars headerinfo and messagebody to inputs
                    t.headerInfo = messageHeader;
                    t.messageBody = messageBody;

                    SubjectCheck = false;

                    //add new tweet to tweetlist object
                    tweetStore.add(t);

                    //display all tweet information to the screen
                    gatherTweetInfo.Items.Add("\nTwitterID: " + t.twitterID);
                    gatherTweetInfo.Items.Add("Tweet Message Header: " + t.headerInfo);
                    gatherTweetInfo.Items.Add("Tweet Message Body: " + t.messageBody);

                    //write object t to json file
                    string strResultJSON = JsonConvert.SerializeObject(t);
                    File.AppendAllText(@"J:\Uni\Year 3\Software Development\Coursework\OFFICIAL\Euston Leisure Messaging (ELM)\tweetInfo.json", strResultJSON);


                    //write to text file at the following url
                    using (TextWriter tw = new StreamWriter(@"J:\Uni\Year 3\Software Development\Coursework\OFFICIAL\Euston Leisure Messaging (ELM)\AllInfo.txt", true))
                    {
                      
                       //writes all info in set format
                       tw.WriteLine(string.Format("TwitterID: {0} \nTweet Header Info: {1} \nTweet Message Body: {2}\n", t.twitterID,  t.headerInfo, t.messageBody));
                        
                    }

                    //clear inputs
                    headerInput.Clear();
                    messageBodyInput.Clear();
                }
            }


           
        }

        //allows users to see the quaratined links that have came off of emails
        private void ViewQuarantinedLinksBtn_Click(object sender, RoutedEventArgs e)
        {
            
            List<Links> linksList = store.list;

            //passing linksList object into the quaratined window 
            QuarantinedWindow linkWin = new QuarantinedWindow(linksList);
            linkWin.ShowDialog();
        }


        /* checks to see if the user has enter characters into both input boxes
         * if not then they will be returned to enter into both boxes */
        private bool inputValidation()
        {
            bool falseinput = false;

            //checks the inputs aren't blank
            if (messageHeader == "" | messageBody == "")
            {
                //prompts user to enter info
                MessageBox.Show("Please enter a message header and a message body");

                falseinput = true;
                return falseinput;

            }

            string line = null;
            
            //new streamreader st to read text file
            using (StreamReader sr = new StreamReader(@"J:\Uni\Year 3\Software Development\Coursework\OFFICIAL\Euston Leisure Messaging (ELM)\AllInfo.txt"))
            {
                //while the line read isn't equal to null
                while((line = sr.ReadLine()) != null)
                {
                    
                    if(line.Contains(messageHeader))
                    {
                        HeaderReInput reInput = new HeaderReInput();
                        reInput.ShowDialog();
                        messageHeader = reInput.reHeaderInput.Text;
                        inputValidation();
                        return falseinput;
                    }

                    return falseinput;
                }
                return falseinput;
            }


        }



        //used to search and return all previously saved data from the AllInfo.txt file
        private void ReadAllStoredData_Click(object sender, RoutedEventArgs e)
        {
            //clear all data from screen
            gatherEmailsListBox.Items.Clear();
            gatherSmsListBox.Items.Clear();
            gatherTweetInfo.Items.Clear();

            //new streamreader to read file
            using (StreamReader sr = new StreamReader(@"J:\Uni\Year 3\Software Development\Coursework\OFFICIAL\Euston Leisure Messaging (ELM)\AllInfo.txt"))
            {
                //line used to hold current line of file
                string line = null;
                //stops when a null value is returned
                while((line = sr.ReadLine()) != null)
                {

                    /*Following lines will search for matches in the text file,
                     * this block searches for any SMS infomation and add its to
                     * the SMS list box
                     * 
                     * if the current line matches any of the if statements, the data
                     * will be added to the appropriate listbox
                     **/

                    if (line.Contains("AreaCode"))
                    {
                        
                        gatherSmsListBox.Items.Add("\n" + line);
                    }

                    if(line.Contains("Phone Number"))
                    {
                        gatherSmsListBox.Items.Add(line);
                    }

                    if(line.Contains("SMS Header Info"))
                    {
                        gatherSmsListBox.Items.Add(line);
                    }

                    if(line.Contains("SMS Message Body"))
                    {
                        gatherSmsListBox.Items.Add(line);
                    }



                    /*Following lines will search for matches in the text file,
                     * this block searches for any Tweet infomation and add its to
                     * the SMS list box
                     * 
                     * if the current line matches any of the if statements, the data
                     * will be added to the appropriate listbox
                     **/

                    if (line.Contains("TwitterID"))
                    {
                        gatherTweetInfo.Items.Add("\n" + line);
                    }

                    if(line.Contains("Hashtags"))
                    {
                        gatherTweetInfo.Items.Add(line);
                    }

                    if(line.Contains("Tweet Header Info"))
                    {
                        gatherTweetInfo.Items.Add(line);
                    }

                    if(line.Contains("Tweet Message Body"))
                    {
                        gatherTweetInfo.Items.Add(line);
                    }


                     /*Following lines will search for matches in the text file,
                     * this block searches for any Email infomation and add its to
                     * the SMS list box
                     * 
                     * if the current line matches any of the if statements, the data
                     * will be added to the appropriate listbox
                     **/

                    if(line.Contains("Sender Email"))
                    {
                        gatherEmailsListBox.Items.Add("\n" + line);
                    }

                    if (line.Contains("Email Recipent"))
                    {
                        gatherEmailsListBox.Items.Add(line);
                    }

                    if (line.Contains("Email Header Info"))
                    {
                        gatherEmailsListBox.Items.Add(line);
                    }

                    if (line.Contains("Email Message Body"))
                    {
                        gatherEmailsListBox.Items.Add(line);
                    }

                    if (line.Contains("Email Type"))
                    {
                        gatherEmailsListBox.Items.Add(line);
                    }

                    if (line.Contains("Email Subject"))
                    {
                        gatherEmailsListBox.Items.Add(line);
                    }

                    if (line.Contains("Sports Centre Code"))
                    {
                        gatherEmailsListBox.Items.Add(line);
                    }

                    if (line.Contains("Nature of incident"))
                    {
                        gatherEmailsListBox.Items.Add(line);
                    }

                    if (line.Contains("Date"))
                    {
                        gatherEmailsListBox.Items.Add(line);
                    }

                }
            }

        }

        private string checkForAbbreviations(string messageBody)
        {
            try
            {
                int positionOfSearchTerm = 0;
                
                //starts the search at 1 instead of binary 0
                positionOfSearchTerm--;

                //reads all lines of the csv file into a string array
                string[] lines = System.IO.File.ReadAllLines(@"J:\Uni\Year 3\Software Development\Coursework\OFFICIAL\Euston Leisure Messaging (ELM)\textwords.csv");

                string upperCaseMessageBody = messageBody;
                //convert to uppercase
                upperCaseMessageBody = upperCaseMessageBody.ToUpper();

                int counter = 0;

                //loops until counter is the same length as the string array lines
                for (counter =0; counter < lines.Length; counter++)
                {


                    //takes 1 line from lines
                    string line = lines[counter];


                    //splits the string on its comma and stores it as string array abbrevation
                    string[] abbrevation = line.Split(',');

                    //searches message box to see if it contains the shortened abbrevation at abbrevation array positon 0
                    if(upperCaseMessageBody.Contains(abbrevation[0]))
                    {
                        int index = 0;
                        //stores the index of the starting char of the abbrevation
                        index = upperCaseMessageBody.IndexOf(abbrevation[0]);

                        int checkPreviousIndex = 0;
                        char checkPreviousChar = ' ';

                        //if index is below 0 then it is outside the array boundaries causing crash
                        if (index != 0)
                        {
                            checkPreviousIndex = index - 1;
                        }
                        //index inside array boundaries meaning we can store the char at any position without crash
                        else
                        {
                            checkPreviousChar = upperCaseMessageBody[checkPreviousIndex];
                        }

                        //stops code from reading abbrevation from middle of word
                        //abbrevations must have a space before them to be read
                        if (char.IsWhiteSpace(checkPreviousChar) && upperCaseMessageBody[index] != '[')
                        {
                            var start = upperCaseMessageBody.IndexOf(abbrevation[0]);
                            //finds the next space after the abbrevation
                            int spaceIndex = index + abbrevation[0].Length;
                            //inserts the expanded abbrevation 
                            upperCaseMessageBody = upperCaseMessageBody.Insert(spaceIndex, " " + "[" + abbrevation[1] + "]");

                            
                        }
                        //this else if will enter when the first word in the message body is the abbreviation
                        else if ( checkPreviousIndex == 0)
                        {
                            /*it is possible that the only word in the string is the abbrevation so no spaces will exist
                             * so space index = the position of the abbreviation + the length of the abbreviation so
                             * we can insert the exanded abbreviation at the end rather than on a space that doesn't exist */
                            int spaceIndex = index + abbrevation[0].Length;
                            //inserts the expanded abbrevation 
                            upperCaseMessageBody = upperCaseMessageBody.Insert(spaceIndex, " " + "[" + abbrevation[1] + "]");

                        }




                    }

                    

                }

                if(counter >= messageBody.Length)
                {
                    messageBody = upperCaseMessageBody.ToLowerInvariant();
                    return messageBody;
                }
                return messageBody;

            }
            catch
            {
                //catch to prevent crash
                MessageBox.Show("Error occured searching for abbrevations");
                //clear vals
                messageBody = "";
                messageHeader = "";
                messageType = "";
                //restart app
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
                return messageBody;
            }
        }

        //used to check for top trending hashtags / mentions
        private void ViewAllTrends_Click(object sender, RoutedEventArgs e)
        {
            //reads all lines of the csv file into a string array
            string[] lines = System.IO.File.ReadAllLines(@"J:\Uni\Year 3\Software Development\Coursework\OFFICIAL\Euston Leisure Messaging (ELM)\AllInfo.txt");
            string[] mentionLines = System.IO.File.ReadAllLines(@"J:\Uni\Year 3\Software Development\Coursework\OFFICIAL\Euston Leisure Messaging (ELM)\AllInfo.txt");

            //index used for storing each hashtag found to the array
            int hashIndex = 0;
            int mentionsIndex = 0;

            string[] hashtagList = new string[30];
            string[] mentionsList = new string[30];

            
            int[] countingArray = new int[30];
            int[] mentionsCountingArray = new int[30];

            //loops through ever line until counter is the same size at lines array
            for (int counter = 0; counter < lines.Length; counter++)
            {
                //set line to current string at position counter
                string line = lines[counter];
                //search for hashtags matchh
                foreach (Match matches in Regex.Matches(line, @"\B(\#[a-zA-Z]+\b)(?!;)"))
                {
                    //adds 1 to number of times occurence of that hashtag has occurred
                    hashIndex = hashIndex + 1;

                    hashtagList[hashIndex] = matches.Value;

                }

            }

            //loops through ever line until counter is the same size at lines array
            for (int counter = 0; counter < mentionLines.Length; counter++)
            {
                //set line to current string at position counter
                string line = mentionLines[counter];
                foreach (Match matches1 in Regex.Matches(line, @"\B(\@[a-zA-Z]+\b)(?!;)"))
                {
                    if (!line.Contains("TwitterID: "))
                    {
                        //adds 1 to number of times occurences of that mention has occurred
                        mentionsIndex = mentionsIndex + 1;

                        mentionsList[mentionsIndex] = matches1.Value;
                    }
                }

            }

            
            int matchesCount = 0;

            //converts array by joining hashtag list on its spaces
            string convertedArray = string.Join(" ", hashtagList);

            //loops until counter is the same size as the hashtaglist length
            for (var counting = 0; counting < hashtagList.Length; counting++)
            {
                //if position isn't null enter if statement
                //this is added to prevent the program from looping through empty array positions
                if(hashtagList[counting] != null)
                {
                    string item = hashtagList[counting];
                    

                    //counts number of occurences of item in converted array
                    matchesCount = Regex.Matches(convertedArray, item).Count;
                    countingArray[counting] = matchesCount;
                    

                }
            }




            string convertedMentionsArray = string.Join(" ", mentionsList);

            for (var counting = 0; counting < mentionsList.Length; counting++)
            {
                //if position isn't null enter if statement
                //this is added to prevent the program from looping through empty array positions
                if(mentionsList[counting]!= null)
                {
                    string item = mentionsList[counting];

                    //counts number of occurences of item in converted array
                    matchesCount = Regex.Matches(convertedMentionsArray, item).Count;
                    mentionsCountingArray[counting] = matchesCount;

                }
            }

            //stores max val in countarray
            int maxValue = countingArray.Max();
            //finds the index of the max value by looking for the highest value
            int maxIndex = countingArray.ToList().IndexOf(maxValue);


            //stores max val in mentionsCountingArray
            int maxMentionsValue = mentionsCountingArray.Max();
            //finds the index of the max value by looking for the highest val in array
            int maxMentionsIndex = mentionsCountingArray.ToList().IndexOf(maxMentionsValue);

            //displays top trending hashtag in hashtag list
            //e.g. hashtag that occurs the most
            MessageBox.Show("Top trending hashtag: " + hashtagList[maxIndex] + " With " + maxValue + " occurences \n" + "Top trending mentions: " + mentionsList[maxMentionsIndex] + " With " + maxMentionsValue + " occurences");
            

            

        }

        //used to display Serious incident reports to screen
        private void SIRoccurences_Click(object sender, RoutedEventArgs e)
        {
            //read file
            using (StreamReader sr = new StreamReader(@"J:\Uni\Year 3\Software Development\Coursework\OFFICIAL\Euston Leisure Messaging (ELM)\AllInfo.txt"))
            {

                
                string line = null;
                //clear email box to allow us to display sir info to screen
                gatherEmailsListBox.Items.Clear();

                //loops while the line isn't null
                while ((line = sr.ReadLine()) != null)
                {
                    
                    //if line contains date then we add it to the email list box
                    if (line.Contains("Date"))
                    {
                        gatherEmailsListBox.Items.Add(line);
                    }

                    //if line contains nature of incident then we display it to the email list box
                    if(line.Contains("Nature of incident"))
                    {
                        gatherEmailsListBox.Items.Add(line);
                    }

                }
            }
        }
    }
}
