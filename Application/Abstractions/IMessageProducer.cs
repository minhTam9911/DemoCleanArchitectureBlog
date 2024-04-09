using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions;
public interface IMessageProducer
{

	public void SendMessage<T>(T message);
	public string? ProcessMessage();

}
