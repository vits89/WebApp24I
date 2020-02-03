using WebApp24I.Models;

namespace WebApp24I.Infrastructure
{
    public interface IMessageProducer
    {
        void Produce(Message message);
    }
}
