﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MousseModels.Models
{
    public class CardViewModel
    {
        /// <summary>
        /// Nombre de colonne que la carte doit prendre.
        /// </summary>
        public int Columns { get; set; }
        /// <summary>
        /// Contenu du body de la carte
        /// </summary>
        public string Content { get; set; }
    }
}