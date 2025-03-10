using AutoMapper;
using Pre_maritalCounSeling.Common.DTOs;
using Pre_maritalCounSeling.DAL.Entities;

namespace Pre_maritalCounSeling.BAL
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<QuizResult, GetQuizResultsResponse>()
               .ForMember(dest => dest.QuizImg, opt => opt.MapFrom(src => src.Quiz.Image))
               .ReverseMap();
        }
    }
}
