using Application.Blogs.Queries.GetList;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blogs.Queries.GetById;
public class GetByIdBlogHandler : IRequestHandler<GetByIdBlogQuery, BlogResponseDto>
{
	private readonly IBlogRepository blogRepository;
	private readonly IMapper mapper;
	public GetByIdBlogHandler(IBlogRepository blogRepository, IMapper mapper)
	{
		this.blogRepository = blogRepository;
		this.mapper = mapper;
	}

	public async Task<BlogResponseDto> Handle(GetByIdBlogQuery request, CancellationToken cancellationToken)
	{
		var blog = await blogRepository.GetAsync(request.Id);
		return mapper.Map<BlogResponseDto>(blog);
	}
}
