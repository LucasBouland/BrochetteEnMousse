using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MousseModels.Models
{
    public class Monster : BaseModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<ScenarioMonster> ScenarioMonsters { get; set; }
    }
}
