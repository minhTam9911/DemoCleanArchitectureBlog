using Application.DTOs.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blogs.Commands.Creates;
public class CreateCommandValidator : AbstractValidator<CreateBlogCommand>
{
	public CreateCommandValidator()
	{

	}

}
