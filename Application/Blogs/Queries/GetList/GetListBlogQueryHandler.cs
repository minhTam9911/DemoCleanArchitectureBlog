using Application.DTOs.Response;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blogs.Queries.GetList;
public class GetListBlogQueryHandler : IRequestHandler<GetListBlogQuery, List<BlogResponseDto>>
{
	private readonly IBlogRepository blogRepository;
	private readonly IMapper mapper;
	public GetListBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
	{
		this.blogRepository = blogRepository;
		this.mapper = mapper;
	}


	public async Task<List<BlogResponseDto>> Handle(GetListBlogQuery request, CancellationToken cancellationToken)
	{
		var blogs = await blogRepository.GetListAsync();
		var blogList = mapper.Map<List<BlogResponseDto>>(blogs);
		return blogList;

	}
}
