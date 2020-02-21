using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using RabbitMQ.Client;
using WebApp24I.AppCore.Entities;
using WebApp24I.AppCore.Interfaces;
using WebApp24I.AppCore.Models;

namespace WebApp24I.Infrastructure.Services
{
    public class MessageProducer : IMessageProducer, IDisposable
    {
        private readonly ConnectionFactory _connectionFactory;

        private IConnection _connection;
        private IModel _channel;

        public MessageProducer(MessageBrokerSettings settings)
        {
            _connectionFactory = new ConnectionFactory
            {
                HostName = settings.HostName,
                Port = settings.Port,
                VirtualHost = settings.VirtualHostName,
                UserName = settings.UserName,
                Password = settings.Password
            };
        }

        public void Produce(Message message)
        {
            CreateConnection();
            CreateChannel();

            DeclareExchange(message.ExchangeName);

            byte[] body = null;

            if (message.Data != null)
            {
                body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message.Data));
            }

            Publish(message.ExchangeName, message.RoutingKey, body);
        }

        public void Dispose()
        {
            Dispose(disposing: true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _channel?.Close();
                _connection?.Close();
            }
        }

        protected virtual void CreateConnection()
        {
            LazyInitializer.EnsureInitialized(ref _connection, () => _connectionFactory.CreateConnection());
        }

        protected virtual void CreateChannel()
        {
            LazyInitializer.EnsureInitialized(ref _channel, () => _connection.CreateModel());
        }

        protected virtual void DeclareExchange(string name)
        {
            _channel.ExchangeDeclare(name, ExchangeType.Topic);
        }

        protected virtual void Publish(string exchangeName, string routingKey, byte[] body = null)
        {
            _channel.BasicPublish(exchangeName, routingKey, body: body);
        }
    }
}
