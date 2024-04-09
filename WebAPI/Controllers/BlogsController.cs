using Application.Abstractions;
using Application.Blogs.Commands.Creates;
using Application.Blogs.Commands.Deletes;
using Application.Blogs.Commands.Updates;
using Application.Blogs.Queries.GetById;
using Application.Blogs.Queries.GetList;
using Application.DTOs.Requests;
using Domain.Entities;
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
	private readonly IMessageProducer messageProducer;
	private readonly IDriverNotificationPublish driverNotificationPublish;

	public BlogsController(IMediator mediator, IMessageProducer messageProducer, IDriverNotificationPublish driverNotificationPublish)
	{
		this.mediator = mediator;
		this.messageProducer = messageProducer;
		this.driverNotificationPublish = driverNotificationPublish;
	}
	public static readonly List<Blog> blogs = new();
	[HttpGet]
	public async Task<IActionResult> GetList()
	{
		var data = await mediator.Send(new GetListBlogQuery());
		return Ok(data);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		var data = await mediator.Send(new GetByIdBlogQuery() { Id = id });
		return Ok(data);
	}

	[HttpPost]
	public async Task<IActionResult> Insert([FromBody] BlogRequestDto blogRequestDto)
	{
		var result = await Sender.Send(new CreateBlogCommand() { BlogRequestDto = blogRequestDto });
		return Ok(result);
	}
	[HttpPut("{id}")]
	public async Task<IActionResult> Update(int id, [FromBody] BlogRequestDto blogRequestDto)
	{
		var result = await Sender.Send(new UpdateBlogCommand() { Id = id, BlogRequestDto = blogRequestDto });
		return Ok(result);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		var result = await Sender.Send(new DeleteBlogCommand() { Id = id });
		return Ok(result);
	}


	[HttpPost("CreateWithRabbiMQ")]
	public IActionResult CreateWithRabbiMQ(Blog blog)
	{
		blogs.Add(blog);
		messageProducer.SendMessage<Blog>(blog);
		var result = messageProducer.ProcessMessage();
		return Ok(result);
	}

	[HttpGet("GetWithRabbiMQ/{id}")]
	public async Task<IActionResult> GetWithRabbiMQ(int id)
	{
		var data = await mediator.Send(new GetByIdBlogQuery() { Id=id});
		driverNotificationPublish.SendNotification(Guid.NewGuid(),data.ToString());
		return Ok(data);
	}

}
