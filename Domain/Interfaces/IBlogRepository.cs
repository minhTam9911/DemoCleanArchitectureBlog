using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces;
public interface IBlogRepository
{

	Task<List<Blog>> GetListAsync();
	Task<Blog> GetAsync(int id);
	Task<int> CreateAsync(Blog blog);
	Task<int> UpdateAsync(int id, Blog blog);
	Task<int> DeleteAsync(int id);

}
