
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MessageSender.Library;
using MessageSender;
using MessengerSender.DAL;
using Twilio.Types;
using System.Linq;

namespace MessengerSenderUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //Test for phone number validation according to the format that Twilio accepts

        [TestMethod]
        public void TestValidatePhoneNumberTrue()
        {
            var validPhoneNumber = Validate.IsValidatePhoneNumber("+50377451247,+50374859874,+50345211245");
            Assert.AreEqual(true,validPhoneNumber);
        }

        //Test for phone number validation according to the format that Twilio not accepts
        [TestMethod]
        public void TestValidatePhoneNumberFalse()
        {
            var validPhoneNumber = Validate.IsValidatePhoneNumber("503 77451247");
            Assert.AreEqual(false, validPhoneNumber);
        }

        [TestMethod]
        public void TestSMSTwilioSendMessageTrue()
        {

            SMSTwilio ObjTest = new SMSTwilio();
            string resultSenMessage = ObjTest.SendingMessagesTwilio("SID",
                                                                    "token", "fromnumber", "toNumber", "Message test API");
            Assert.IsNotNull(resultSenMessage);
        }

        [TestMethod]
        public void TestSMSTwilioSendMessageFalse()
        {
            SMSTwilio ObjTest = new SMSTwilio();
            string resultSenMessage = ObjTest.SendingMessagesTwilio("X",
                                                                    "T", "from", "to", "Message test API");
            Assert.IsNull(resultSenMessage);
        }

    }
}
