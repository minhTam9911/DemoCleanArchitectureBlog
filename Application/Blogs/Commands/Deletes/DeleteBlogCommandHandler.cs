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

namespace Application.Blogs.Commands.Deletes;
public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, ServiceResponse>
{
	private readonly IBlogRepository blogRepository;
	private readonly IMapper mapper;
	public DeleteBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
	{
		this.blogRepository = blogRepository;
		this.mapper = mapper;
	}

	public async Task<ServiceResponse> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
	{
		var result = await blogRepository.DeleteAsync(request.Id);
		if (result > 0) return new ServiceResponse(true, "Deleted");
		return new ServiceResponse(false, "Failure");
	}
}
