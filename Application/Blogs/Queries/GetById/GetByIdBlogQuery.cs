using Application.Blogs.Queries.GetList;
using Application.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blogs.Queries.GetById;
public class GetByIdBlogQuery : IRequest<BlogResponseDto>
{

	public int Id { get; set; }

}
