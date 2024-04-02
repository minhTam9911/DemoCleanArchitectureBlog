using Application.Blogs.Commands.Creates;
using Application.Blogs.Commands.Deletes;
using Application.Blogs.Commands.Updates;
using Application.Blogs.Queries.GetById;
using Application.Blogs.Queries.GetList;
using Application.DTOs.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BlogsController : ApiControllerBase
{

	private readonly IMediator mediator;

	public BlogsController(IMediator mediator)
	{
		this.mediator = mediator;
	}

	[HttpGet]
	public async Task<IActionResult> GetList()
	{
		var data = await mediator.Send(new GetListBlogQuery());
		return Ok(data);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		var data = await mediator.Send(new GetByIdBlogQuery() {Id = id });
		return Ok(data);
	}

	[HttpPost]
	public async Task<IActionResult> Insert([FromBody] BlogRequestDto blogRequestDto)
	{
		var result = await Sender.Send(new CreateBlogCommand() { BlogRequestDto = blogRequestDto});
		return Ok(result);
	}
	[HttpPut("{id}")]
	public async Task<IActionResult> Update(int id,[FromBody] BlogRequestDto blogRequestDto)
	{
		var result = await Sender.Send(new UpdateBlogCommand() { Id = id, BlogRequestDto = blogRequestDto });
		return Ok(result);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete (int id)
	{
		var result = await Sender.Send(new DeleteBlogCommand() { Id = id});
		return Ok(result);
	}

}
