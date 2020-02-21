using WebApp24I.AppCore.Entities;

namespace WebApp24I.AppCore.Interfaces
{
    public interface IMessageProducer
    {
        void Produce(Message message);
    }
}
