using Application.Abstractions;
using Application.DTOs.Response;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;
public class DriverNotificationPublish : IDriverNotificationPublish
{
	private readonly ILogger<DriverNotificationPublish> logger;
	private readonly IPublishEndpoint bus;

	public DriverNotificationPublish(ILogger<DriverNotificationPublish> logger, IPublishEndpoint bus)
	{
		this.logger = logger;
		this.bus = bus;
	}

	public async Task SendNotification(Guid driverId, string nameBlog)
	{
		logger.LogInformation("Driver notification for "+driverId+" and "+ nameBlog);
		await bus.Publish(new DriverNotificationRecord(driverId, nameBlog));
	}
}
