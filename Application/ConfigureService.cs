using Application.Abstractions;
using Application.Blogs.Queries.GetList;
using Application.Commons.Behaviours;
using Application.Services;
using Domain.Interfaces;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application;
public static class ConfigureService
{

	public static IServiceCollection AddApplicationService(this IServiceCollection services)
	{
		services.AddAutoMapper(Assembly.GetExecutingAssembly());
		services.AddMediatR(ctg =>
		{
			ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
			ctg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
		});
		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
		services.AddScoped<IMessageProducer, MessageProducer>();
		services.AddScoped<IDriverNotificationPublish, DriverNotificationPublish>();
		services.AddMassTransit(busConfig =>
		{

			busConfig.SetKebabCaseEndpointNameFormatter();
			busConfig.SetInMemorySagaRepositoryProvider();

			busConfig.AddConsumers(Assembly.GetExecutingAssembly());
			busConfig.AddSagaStateMachines(Assembly.GetExecutingAssembly());
			busConfig.AddSagas(Assembly.GetExecutingAssembly());
			busConfig.AddActivities(Assembly.GetExecutingAssembly());
			busConfig.UsingRabbitMq((context, configuration) =>
			{
				configuration.Host("localhost", "/", h =>
				{
					h.Username("guest");
					h.Password("guest");
				});
				configuration.ConfigureEndpoints(context);
			});
		});
		return services;
	}

}
