using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blogs.Commands.Creates;
public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, ServiceResponse>
{
	private readonly IBlogRepository blogRepository;
	private readonly IMapper mapper;
	public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
	{
		this.blogRepository = blogRepository;
		this.mapper = mapper;
	}

	public async Task<ServiceResponse> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
	{
		var blog = mapper.Map<Blog>(request.BlogRequestDto);
		var result = await blogRepository.CreateAsync(blog);
		if (result > 0) return new ServiceResponse(true, "Inserted");
		return new ServiceResponse(false, "Failure");
	}
}
