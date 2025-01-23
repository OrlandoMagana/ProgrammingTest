using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSender.Models
{
    [Table(Schema = "dbo", Name = "CredentialsTwilio")]
    public class CredentialsTwilio
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column, NotNull]
        public string SID { get; set; }
        [Column, NotNull]
        public string Token { get; set; }
        [Column, NotNull]
        public string FromNumber { get; set; }

    }
}
