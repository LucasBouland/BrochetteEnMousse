using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static MousseModels.Helpers;

namespace MousseModels.Models
{
    public class Scenario : BaseModel
    {
        public Scenario()
        {
            Visibility = Visibility.Members;
        }
        [Required]
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public Visibility Visibility { get; set; }
        public ICollection<ScenarioMonster> ScenarioMonsters { get; set; }
        public ICollection<ScenarioSession> ScenarioSessions { get; set; }
    }
}
