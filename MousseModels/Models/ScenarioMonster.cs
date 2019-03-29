using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MousseModels.Models
{
    public class ScenarioMonster : BaseModel
    {
        public string ScenarioID { get; set; }
        [ForeignKey("ScenarioID")]
        public Scenario Scenario { get; set; }
        public string MonsterID { get; set; }
        [ForeignKey("MonsterID")]
        public Monster Monster { get; set; }
    }
}
