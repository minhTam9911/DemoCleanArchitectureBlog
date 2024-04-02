using Application.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blogs.Commands.Deletes;
public class DeleteBlogCommand : IRequest<ServiceResponse>
{
	public int Id { get; set; }
}
