using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;
using MessageSender.Models;

namespace MessageSender.DB.Models.Models
{
    public class MessageModel : PropertyChangedNotification
    {
        public int Id { get; set; }
        public string CodeTwilio { get; set; }
        public string PhoneNumber
        {
            get { return GetValue(() => PhoneNumber); }
            set 
            { 
                SetValue(() => PhoneNumber,value);
                PhoneNumberMessage = "";
                Messages = "";
            }
        }
        public string MessageBody
        {
            get { return GetValue(() => MessageBody); }
            set
            {
                SetValue(() => MessageBody, value);
                MessageBodyMessage = "";
                Messages = "";
            }

        }

        public string Created { get; set; }
        public string Messages
        {
            get { return GetValue(() => Messages);}
            set {SetValue(() => Messages, value);}
        }
        public string PhoneNumberMessage
        {
            get { return GetValue(() => PhoneNumberMessage); }
            set { SetValue(() => PhoneNumberMessage, value); }
        }
        public string MessageBodyMessage
        {
            get { return GetValue(() => MessageBodyMessage); }
            set { SetValue(() => MessageBodyMessage, value); }
        }
        //ListOfMessages
        public List<MessageModel> ListOfMessages
        {
            get { return GetValue(() => ListOfMessages); }
            set { SetValue(() => ListOfMessages, value); }
        }

    }
}
