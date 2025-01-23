using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageSerder.Models
{
    [Table(Schema = "dbo", Name = "SentMessage")]
    public class SentMessage
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column, NotNull]
        public int MessageId { get; set; }
        [Column, NotNull]
        public DateTime SentDate { get; set; }
        [Column, NotNull]
        public string CodeTwilio { get; set; }

    }
}
