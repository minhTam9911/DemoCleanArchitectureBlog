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

namespace Application.Blogs.Commands.Updates;
public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, ServiceResponse>
{
	private readonly IBlogRepository blogRepository;
	private readonly IMapper mapper;
	public UpdateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
	{
		this.blogRepository = blogRepository;
		this.mapper = mapper;
	}

	public async Task<ServiceResponse> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
	{
		var blog = mapper.Map<Blog>(request.BlogRequestDto);
		var result = await blogRepository.UpdateAsync(request.Id,blog);
		if (result > 0) return new ServiceResponse(true, "Updated");
		return new ServiceResponse(false, "Failure");
	}
}
