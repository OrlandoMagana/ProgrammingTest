using MessageSender.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageSerder.DB.Models.Models
{
    public class SentMessageModel : PropertyChangedNotification
    {
        public int Id { get; set; }
        public int MessageId
        {
            get { return GetValue(() => MessageId); }
            set
            {
                SetValue(() => MessageId, value);
            }
        }

        public DateTime SentDate
        {
            get { return GetValue(() => SentDate); }
            set
            {
                SetValue(() => SentDate, value);
            }
        }

        public string CodeTwilio
        {
            get { return GetValue(() => CodeTwilio); }
            set
            {
                SetValue(() => CodeTwilio, value);
            }
        }


    }
}
