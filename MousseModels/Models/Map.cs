using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MousseModels.Models
{
    public class Map : BaseModel
    {
        public string ScenarioID { get; set; }
        [ForeignKey("ScenarioID")]
        public Scenario Scenario { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public byte[] Image { get; set; }
    }
}
