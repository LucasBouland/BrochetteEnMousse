using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MousseModels.Models
{
    public class SessionUser : BaseModel
    {
        public string SessionID { get; set; }
        [ForeignKey("SessionID")]
        public Session Session { get; set; }
        public string UserID { get; set; }
        [ForeignKey("SessionID")]
        public User User { get; set; }
    }
}
