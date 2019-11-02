using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessList
{
    //By Callum Buttery
    //Last edited 28/10/19

        //used to assign values to an email object
        //e.g. give an email object a sender email

    public class Emails
    {
        private string _senderEmail;
        private string _recEmail;
        private string _selectedEmailType;
        private string _emailSubject;
        private string _sportsCentreCode;
        private string _natureOfSIR;
        private string _dt;
        private string _headerInfo;
        private string _messageBody;

        public string email
        {
            get
            {
                return _senderEmail;
            }
            set
            {
                _senderEmail = value;
            }

        }

        public string recEmail
        {
            get
            {
                return _recEmail;
            }
            set
            {
                _recEmail = value;
            }
        }

        public string selectedEmailType
        {
            get
            {
                return _selectedEmailType;
            }
            set
            {
                _selectedEmailType = value;
            }
        }

        public string emailSubject
        {
            get
            {
                return _emailSubject;
            }
            set
            {
                _emailSubject = value;
            }

        }

        public string sportsCentreCode
        {
            get
            {
                return _sportsCentreCode;
            }
            set
            {
                _sportsCentreCode = value;
            }
        }

        public string natureOfSIR
        {
            get
            {
                return _natureOfSIR;
            }
            set
            {
                _natureOfSIR = value;
            }
        }

        public string dateTime
        {
            get
            {
                return _dt;
            }
            set
            {
                _dt = value;
            }
        }

        public string headerInfo
        {
            get
            {
                return _headerInfo;
            }
            set
            {
                _headerInfo = value;
            }
        }

        public string messageBody
        {
            get
            {
                return _messageBody;
            }
            set
            {
                _messageBody = value;
            }
        }

    }


    //USed for testing purposes
    public class AddedEmail
    {
        public bool EmailAdded (Emailvar emailvar)
        {

            
            string testblankEmail = "";
            string realemail = "test@test.com";

            if (realemail.Contains('@'))
                return true;


            if (realemail != testblankEmail)
                return true;

           return false;

        }
    }


    public class AddedRecEmail
    {
        public bool RecEmailAdded(RecEmailVar recemailvar)
        {
            string testrecemail = "test@test.com";
            string blankEmail = "";

            if (testrecemail != blankEmail)
                return true;

            return false;
        }

        public bool RecEmailNotAdded(RecEmailVar recemailvar)
        {
            string testrecemail = "";
            string blankEmail = "";

            if (testrecemail == blankEmail)
                return false;

            return false;

        }
    }

    public class Emailvar
    {
        public bool IsAdded { get; set; }
    }

    public class RecEmailVar
    {
        public bool IsAdded { get; set; }
    }

}
