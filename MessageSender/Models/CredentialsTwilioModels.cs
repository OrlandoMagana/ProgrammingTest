using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSender.Models
{
    public class CredentialsTwilioModels : PropertyChangedNotification
    {
        public int Id { get; set; }
        public int SID 
        {
            get {return GetValue(() => SID);}
            set {SetValue(() => SID, value);}
        }
        public string Token
        {
            get { return GetValue(() => Token); }
            set { SetValue(() => Token, value); }
        }

        public string FromNumber
        {
            get { return GetValue(() => Token); }
            set { SetValue(() => Token, value); }
        }



    }
}
