﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ApiControllerBase : ControllerBase
{

	private ISender _sender;

	protected ISender Sender
	=> _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();

}
