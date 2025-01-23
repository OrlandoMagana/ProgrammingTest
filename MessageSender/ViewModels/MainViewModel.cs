using LinqToDB;
using MessageSender.DB.Models.Models;
using MessageSender.Library;
using MessageSerder.DB.Models.Models;
using MessengerSender.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;



namespace MessageSender.ViewModels
{
    public class MainViewModel:MessageModel
    {
        private ICommand _command;
        private TextBox _phoneNumerBox;
        private TextBox _messageBodyBox;
        private Frame rootFrame = Window.Current.Content as Frame;
        private Connections _conn;
        private SMSTwilio sms = new SMSTwilio();
        public MainViewModel(object[] fields)
        {
            _phoneNumerBox = (TextBox)fields[0];
            _messageBodyBox = (TextBox)fields[1];
            _conn = new Connections();

        }
        public MainViewModel()
        {
            _conn = new Connections();
            GetMessagesAsync();
        }
        public ICommand StartCommand
        {
            get 
            {
                return _command ?? (_command = new CommandHandler(async () => 
                {
                    await startAsync();
                }));
            }
        }
        private async Task startAsync()
        {
            if (PhoneNumber == null || PhoneNumber.Equals(""))
            {
                PhoneNumberMessage = "Please fill out the phone number field";
                //_phoneNumerBox.Focus(FocusState.Programmatic);
            }
            else
            {
                if (Validate.IsValidatePhoneNumber(PhoneNumber))
                {
                    if (MessageBody == null || MessageBody.Equals(""))
                    {
                        MessageBodyMessage = "Please fill out the Message field";
                        //_messageBodyBox.Focus(FocusState.Programmatic);
                    }
                    else
                    {
                        string[] PhonesNumbers = PhoneNumber.Split(',');
                        string Sid = _conn.TCredentialsTwilio.ToList().FirstOrDefault().SID.ToString();
                        string token = _conn.TCredentialsTwilio.ToList().FirstOrDefault().Token.ToString();
                        string fromnumber = _conn.TCredentialsTwilio.ToList().FirstOrDefault().FromNumber.ToString();

                        foreach (var itemphonepumber in PhonesNumbers)
                        {
                            string messageResult = sms.SendingMessagesTwilio(
                                                                    Sid,
                                                                    token,
                                                                    fromnumber,
                                                                    itemphonepumber,
                                                                    MessageBody);
                            if (!string.IsNullOrEmpty(messageResult))
                            {
                                messageResult = messageResult.Substring(messageResult.LastIndexOf('/') + 1, messageResult.Length - (messageResult.LastIndexOf('/') + 1));

                                Save(messageResult.Replace(".json", ""), itemphonepumber);
                                GetMessagesAsync();
                            }
                        }
                    }
                }
                else
                {
                    PhoneNumberMessage = "phone number is not valid";
                    //_phoneNumerBox.Focus(FocusState.Programmatic);
                }
            }
        }

        public bool Save(string code, string numberphone) 
        {

            try
            {
                var resultMessage = _conn.TMessages.Value(u => u.PhoneNumber, numberphone)
                                            .Value(u => u.MessageBody, MessageBody)
                                            .Insert();
                var lastIdMessage = _conn.TMessages.AsEnumerable().LastOrDefault();
                try
                {
                    var resultSentMessage = _conn.TSentMessages.Value(u => u.MessageId, lastIdMessage.Id)
                                                .Value(u => u.CodeTwilio, code)
                                                .Insert();
                    return true;
                }
                catch (Exception e)
                {
                    var dialog = new MessageDialog(e.ToString());
                    _ = dialog.ShowAsync();
                    return false;
                }

            }
            catch (Exception e)
            {
                var dialog = new MessageDialog(e.ToString());
                _ = dialog.ShowAsync();
                return false;
            }
        }

        public async Task GetMessagesAsync()
        {
            var ListOfMessage = new List<MessageModel>();
            var list = _conn.TMessages.ToList();
            if( list.Count > 0)
            {
                foreach (var item in list)
                {
                    var code = _conn.TSentMessages.Where(u => u.MessageId == item.Id).AsEnumerable().FirstOrDefault();
                    ListOfMessage.Add(new MessageModel
                    {
                        PhoneNumber = item.PhoneNumber,
                        MessageBody = item.MessageBody,
                        Created = item.Created.ToString("dd/MM/yyyy HH:mm:ss"),
                        CodeTwilio = code.CodeTwilio.ToString()
                    });
                }
                ListOfMessages = ListOfMessage;
            }
        }
    }
}
