using Application.Blogs.Queries.GetList;
using Application.Commons.Behaviours;
using Domain.Interfaces;
using FluentValidation;
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
		return services;
	}

}
