using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Requests;
public class BlogRequestDto
{
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public string Author { get; set; } = string.Empty;
	public string Title { get; set; } = string.Empty;
}
