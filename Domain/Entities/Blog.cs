using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Blog
{
	
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Description {  get; set; } = string.Empty;
	public string Author {  get; set; } = string.Empty;
	public string Title { get; set; } = string.Empty;
}
