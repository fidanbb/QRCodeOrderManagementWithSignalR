using AutoMapper;
using SignalR.DtoLayer.FooterDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPi.Mapping
{
    public class FooterMapping:Profile
    {
        public FooterMapping()
        {
            CreateMap<Footer, ResultFooterDto>().ReverseMap();
            CreateMap<Footer, CreateFooterDto>().ReverseMap();
            CreateMap<Footer, UpdateFooterDto>().ReverseMap();
            CreateMap<Footer, GetFooterDto>().ReverseMap();
        }
    }
}
