using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApp24I.Infrastructure;
using WebApp24I.Models;
using WebApp24I.ViewModels;

namespace WebApp24I.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageProducer _messageProducer;
        private readonly IMapper _mapper;

        public MessagesController(IMessageProducer messageProducer, IMapper mapper)
        {
            _messageProducer = messageProducer;
            _mapper = mapper;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(MessageViewModel messageVm)
        {
            var message = _mapper.Map<Message>(messageVm);

            _messageProducer.Produce(message);

            return NoContent();
        }
    }
}
