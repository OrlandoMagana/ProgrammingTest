using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;
using LinqToDB.Mapping;

namespace MessageSerder.Models
{
    [Table(Schema = "dbo", Name = "Message")]
    public class Message
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column, NotNull]
        public DateTime Created { get; set; }
        [Column, NotNull]
        public string PhoneNumber { get; set; }
        [Column, NotNull]
        public string MessageBody { get; set; }
        public SentMessage SentMessages { get; set; }

    }
}
