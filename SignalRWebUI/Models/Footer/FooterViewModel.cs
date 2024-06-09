using SignalRWebUI.Dtos.ContactDtos;
using SignalRWebUI.Dtos.FooterDtos;
using SignalRWebUI.Dtos.SocialMediaDtos;

namespace SignalRWebUI.Models.Footer
{
    public class FooterViewModel
    {
        public ResultContactDto Contact { get; set; }
        public List<ResultSocialMediaDto> SocialMedias { get; set; }
        public ResultFooterDto Footer { get; set; }
    }
}
