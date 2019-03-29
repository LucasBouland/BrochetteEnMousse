using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MousseModels.Models
{
    public class ScenarioSession : BaseModel
    {
        public string ScenarioID { get; set; }
        [ForeignKey("ScenarioID")]
        public Scenario Scenario { get; set; }
        public string SessionID { get; set; }
        [ForeignKey("SessionID")]
        public Session Session { get; set; }
    }
}
