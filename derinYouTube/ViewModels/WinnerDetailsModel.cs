﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derinYouTube.ViewModels
{
    public class WinnerDetailsModel : CompetitionResultModel
    {
        [DisplayName("Soru")]
        public string Question { get; set; }
    }
}