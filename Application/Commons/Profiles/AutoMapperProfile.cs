using Application.DTOs.Requests;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;

namespace Application.Commons.Mappings;
public class AutoMapperProfile : Profile
{

	public AutoMapperProfile() {
		CreateMap<BlogRequestDto, Blog>();
		CreateMap<Blog, BlogResponseDto>();
	}

	
}
