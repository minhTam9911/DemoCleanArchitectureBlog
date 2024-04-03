using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Requests;
public class BlogRequestDto
{
	[Required]
	public string Name { get; set; } = string.Empty;
	[Required]
	public string Description { get; set; } = string.Empty;
	[Required]
	public string Author { get; set; } = string.Empty;
	[Required]
	[MinLength(5)]
	public string Title { get; set; } = string.Empty;
}
