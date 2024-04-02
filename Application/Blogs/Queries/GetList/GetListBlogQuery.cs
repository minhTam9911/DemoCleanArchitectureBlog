using Application.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blogs.Queries.GetList;
public class GetListBlogQuery : IRequest<List<BlogResponseDto>>
{

}

//public record GetQuery : IRequest<List<BlogVm>>;

