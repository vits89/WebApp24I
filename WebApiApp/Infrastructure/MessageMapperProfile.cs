using AutoMapper;
using WebApp24I.AppCore.Entities;
using WebApp24I.WebApiApp.ViewModels;

namespace WebApp24I.WebApiApp.Infrastructure
{
    public class MessageMapperProfile : Profile
    {
        public MessageMapperProfile()
        {
            CreateMap<MessageViewModel, Message>();
        }
    }
}
