using Application.DTOs.Requests;
using Application.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blogs.Commands.Updates;
public class UpdateBlogCommand : IRequest<ServiceResponse>
{

	public int Id;
	public BlogRequestDto BlogRequestDto;

}
