using Application.Blogs.Queries.GetList;
using Application.DTOs.Requests;
using Application.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blogs.Commands.Creates;
public class CreateBlogCommand : IRequest<ServiceResponse>
{
	public BlogRequestDto? BlogRequestDto;
}
