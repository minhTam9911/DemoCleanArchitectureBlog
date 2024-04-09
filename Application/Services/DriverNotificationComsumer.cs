using Application.DTOs.Response;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;
public class DriverNotificationComsumer : IConsumer<DriverNotificationRecord>
{
	private readonly ILogger<DriverNotificationPublish> logger;

	public DriverNotificationComsumer(ILogger<DriverNotificationPublish> logger)
	{
		this.logger = logger;
	}

	public Task Consume(ConsumeContext<DriverNotificationRecord> context)
	{
		logger.LogInformation("Driver notification for " + context.Message.driverId + " and " + context.Message.nameBlog);
		return Task.CompletedTask;
	}
}
