using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MousseModels.Models
{
    public abstract class BaseModel
    {
        public string ID { get; set; }
    }
}
