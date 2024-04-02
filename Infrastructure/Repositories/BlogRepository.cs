using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;
public class BlogRepository : IBlogRepository
{
	private readonly AppDbContext appDbContext;

	public BlogRepository(
		AppDbContext appDbContext
	){
		this.appDbContext = appDbContext;
	}

	public async Task<int> CreateAsync(Blog blog)
	{
		if(await appDbContext.Blogs.FirstOrDefaultAsync(x=> x.Name == blog.Name) != null)
		{
			return 0;
		}
		await appDbContext.Blogs.AddAsync(blog);
		return await appDbContext.SaveChangesAsync();

	}

	public  async Task<int> DeleteAsync(int id)
	{
		if (await appDbContext.Blogs.FirstOrDefaultAsync(x => x.Id == id) == null)
		{
			return 0;
		}
		appDbContext.Blogs.Remove(await appDbContext.Blogs.FindAsync(id));
		return await appDbContext.SaveChangesAsync();
	}

	public async Task<Blog> GetAsync(int id)
	{
		return await appDbContext.Blogs.FirstOrDefaultAsync(x=>x.Id == id);
	}

	public async Task<List<Blog>> GetListAsync()
	{
		return await appDbContext.Blogs.ToListAsync();
	}

	public async Task<int> UpdateAsync(int id, Blog blog)
	{
		if (await appDbContext.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id) == null)
		{
			return 0;
		}
		if (await appDbContext.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.Name == blog.Name && x.Id!=id) != null)
		{
			return 0;
		}
		var data = await appDbContext.Blogs.FindAsync(id);
		data.Author = blog.Author;
		data.Description = blog.Description;
		data.Name = blog.Name;
		data.Title = blog.Title;
		appDbContext.Entry(data).State = EntityState.Modified;
		return await appDbContext.SaveChangesAsync();
	}
}
