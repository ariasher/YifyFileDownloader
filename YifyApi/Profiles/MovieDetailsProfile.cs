using AutoMapper;
using YifyApi.Models.DTOs;
using YifyCommon.Models.DataModels;

namespace YifyApi.Profiles
{
    public class MovieDetailsProfile : Profile
    {
        public MovieDetailsProfile()
        {
            CreateMap<MovieDetails, MovieDTO>()
                .ForMember(dest => dest.CreatedAt,
                       opt => opt.MapFrom(src => src.CreatedAt.ToString("dd-MM-yyyy hh:mm:stt")))
                .ForMember(dest => dest.UpdatedAt,
                       opt => opt.MapFrom(src => src.UpdatedAt.ToString("dd-MM-yyyy hh:mm:sstt")));

            CreateMap<MovieDetails, MovieWithTorrentDTO>()
                .ForMember(dest => dest.CreatedAt,
                       opt => opt.MapFrom(src => src.CreatedAt.ToString("dd-MM-yyyy hh:mm:sstt")))
                .ForMember(dest => dest.UpdatedAt,
                       opt => opt.MapFrom(src => src.UpdatedAt.ToString("dd-MM-yyyy hh:mm:sstt")));
        }
    }
}
