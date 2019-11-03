using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessList
{
    //By Callum Buttery
    //Last edited 28/10/19


    //used to assign values to sms object
    //e.g. assign a senderNUmber to an sms text
    public class Sms
    {

        private string _senderNumber;
        private string _areaCode;
        private string _headerInfo;
        private string _messageBody;

        public string senderNumber
        {
            get
            {
                return _senderNumber;
            }
            set
            {
                _senderNumber = value;
            }


        }

        public string areaCode
        {
            get
            {
                return _areaCode;
            }
            set
            {
                _areaCode = value;
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
    public class Added
    {
      
       
        

        public bool PhoneNoIsAdded(PhoneNo phoneno)
        {
            if (phoneno.IsAdded)
                return true;

            return false;
        }

        public bool areaCodeAdded(AreaCode areaCode)
        {
            string area_code = "+44";
            string test_Area_code = "+44";

            if (area_code == test_Area_code)
                return true;

            return false;
        }

        public bool areaCodeNotAdded(AreaCode areaCode)
        {
            string area_code = "+44";
            string test_Area_code = "";

            if (area_code != test_Area_code)
                return false;

            return true;
        }



        public bool headerAdded(HeaderInfo headerinfo)
        {
            string headerLoaded = "set123456789";
            if (headerLoaded != null)
                return true;

            return false;
        }

        public bool headerNotAdded(HeaderInfo headerinfo)
        {
            string headerNotLoaded = "set12345678910";
            if (headerNotLoaded.Length > 9)
                return false;

            return true;
        }





        public bool messageBodyAdded(MessageBodyInfo messagebodyinfo)
        {
            string messagebodyloaded = "This is a test message body";
            if (messagebodyloaded.Length < 1028)
                return true;

            return false;
        }

        public bool messageBodyNotAdded(MessageBodyInfo messageBodyInfo)
        {
            string messagebodynotloaded = null;
            if (messagebodynotloaded == null)
                return true;

            return false;
        }

    }

    public class PhoneNo
    {
        public bool IsAdded { get; set; }
    }
    
    public class AreaCode
    {
        public bool IsAdded { get; set; }
    }


    public class HeaderInfo
    {
        public bool IsAdded { get; set; }
    }

    public class MessageBodyInfo
    {
        public bool IsAdded { get; set; }
    }

}
