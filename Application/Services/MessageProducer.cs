using Application.Abstractions;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Services;
public class MessageProducer : IMessageProducer
{
	public string? ProcessMessage()
	{
		string message = string.Empty;
		ConnectionFactory factory = new()
		{
			HostName = "localhost",
			UserName = "guest",
			Password = "guest",
			VirtualHost = "/"
		};
		IConnection connection = factory.CreateConnection();
		IModel channel = connection.CreateModel();
		string exchangeName = "DemoExchange";
		string routingKey = "demo-routing-key";
		string queueName = "DemoQueue";
		channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
		channel.QueueDeclare(queueName, false, false, false, null);
		channel.QueueBind(queueName, exchangeName, routingKey, null);

		var consumer = new EventingBasicConsumer(channel);
		consumer.Received += (model, eventArgs) =>
		{
			var body = eventArgs.Body.ToArray();
			 message += Encoding.UTF8.GetString(body);

		};

		channel.BasicConsume(queueName, true,consumer);
		channel.Close();
		connection.Close();
		return message;
	}

	public void SendMessage<T>(T message)
	{
		ConnectionFactory factory = new();
		factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
		factory.ClientProvidedName = "RabbitMQ Sender";
		IConnection connection = factory.CreateConnection();
		IModel channel = connection.CreateModel();
		string exchangeName = "DemoExchange";
		string routingKey = "demo-routing-key";
		string queueName = "DemoQueue";
		channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
		channel.QueueDeclare(queueName, false, false, false, null);
		channel.QueueBind(queueName, exchangeName, routingKey,null);
		var jsonString = JsonSerializer.Serialize(message);
		var body = Encoding.UTF8.GetBytes(jsonString);
		channel.BasicPublish(exchangeName,routingKey, basicProperties:null,body:body);
		channel.Close();
		connection.Close();
	}
}
