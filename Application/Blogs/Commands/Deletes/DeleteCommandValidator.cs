﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blogs.Commands.Deletes;
public class DeleteCommandValidator : AbstractValidator<DeleteBlogCommand>
{

	public DeleteCommandValidator() { }

}
