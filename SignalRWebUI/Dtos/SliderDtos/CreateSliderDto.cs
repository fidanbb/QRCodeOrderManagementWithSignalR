﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.SliderDtos
{
    public class CreateSliderDto
    {
        public string Title { get; set; }
        public int Row { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}