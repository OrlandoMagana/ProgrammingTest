using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;
using MessageSender.Models;
using MessageSerder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerSender.DAL
{
    public class Connections : DataConnection
    {
        public Connections() : base(new LinqToDB.DataProvider.SqlServer.SqlServerDataProvider("",
                SqlServerVersion.v2017),
            "Data Source=DESKTOP-RU6TCN5\\SQLEXPRESS;Initial Catalog=MessageSenderDB;Integrated Security=True")
            //"Data Source=PERSONAL\\SQLEXPRESS;Initial Catalog=MessengerSender;Integrated Security=True")
        {
            
        }

        public ITable<Message> TMessages => GetTable<Message>();
        public ITable<SentMessage> TSentMessages => GetTable<SentMessage>();
        public ITable<CredentialsTwilio> TCredentialsTwilio => GetTable<CredentialsTwilio>();
    }
}
