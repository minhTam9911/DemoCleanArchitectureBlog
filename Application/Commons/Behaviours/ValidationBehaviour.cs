using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons.Behaviours;
public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
	private readonly IEnumerable<IValidator<TRequest>> validators;

	public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
	{
		this.validators = validators;
	}

	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		if(validators.Any())
		{
			var context = new ValidationContext<TRequest>(request);
			var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
			var failures = validationResults.Where(x => x.Errors.Any()).SelectMany(x=>x.Errors).ToList();
			if(failures.Any())
			{
				throw new ValidationException(failures);
			}
		}
		return await next();
	}
}
