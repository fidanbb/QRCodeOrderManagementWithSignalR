﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Footer
    {
        public int FooterID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string OpeningDays { get; set; }
        public string OpeningTimes { get; set; }
    }
}
