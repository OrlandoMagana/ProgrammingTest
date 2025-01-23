using System;
using System.Collections.Generic;
using System.Text;

namespace MessageSerder.DB.Models.Models
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string PhoneNumber { get; set; }
        public string MessageBody { get; set; }

        public ICollection<SentMessage> SentMessage { get; set; }

    }
}
