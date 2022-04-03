using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SecurityDevelopment.Models;
using SecurityDevelopment.DTO;

namespace SecurityDevelopment.Mapper
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			CreateMap<PersonDTO, Person>().ReverseMap();

			CreateMap<DebetCardDTO, DebetCard>().ReverseMap();
		}
	}
}
