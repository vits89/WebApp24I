using AutoMapper;
using WebApp24I.Models;
using WebApp24I.ViewModels;

namespace WebApp24I.Infrastructure
{
    public class MessageMapperProfile : Profile
    {
        public MessageMapperProfile()
        {
            CreateMap<MessageViewModel, Message>();
        }
    }
}
