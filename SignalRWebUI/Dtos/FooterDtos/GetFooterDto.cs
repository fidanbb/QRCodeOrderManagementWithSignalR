using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.FooterDtos
{
    public class GetFooterDto
    {
        public int FooterID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string OpeningDays { get; set; }
        public string OpeningTimes { get; set; }
    }
}
