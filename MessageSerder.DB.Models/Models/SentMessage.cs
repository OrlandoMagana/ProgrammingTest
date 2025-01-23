using System;
using System.Collections.Generic;
using System.Text;

namespace MessageSerder.DB.Models.Models
{
    public class SentMessage
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public DateTime SentDate { get; set; }
        public string CodeTwilio { get; set; }

    }
}
