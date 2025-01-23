using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace MessageSender.Library
{
    public class SMSTwilio
    {
        public string SendingMessagesTwilio(string SID, string token,string ftom, string to, string messagebody)
        {
            var accountSid = SID;
            var authToken = token;
            TwilioClient.Init(accountSid, authToken);

            try
            {
                var messageOptions = new CreateMessageOptions(
                  new PhoneNumber(to));
                messageOptions.From = new PhoneNumber(ftom);
                messageOptions.Body = messagebody;


                return MessageResource.Create(messageOptions).Uri.ToString();
            }
            catch (TwilioException ex)
            {
                // An exception occurred making the REST call
                return null;
            }
        }
    }
}
