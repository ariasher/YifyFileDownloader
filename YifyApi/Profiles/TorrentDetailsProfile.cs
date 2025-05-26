using AutoMapper;
using YifyApi.Models.DTOs;
using YifyCommon.Models.DataModels;

namespace YifyApi.Profiles
{
    public class TorrentDetailsProfile: Profile
    {
        public TorrentDetailsProfile()
        {
            CreateMap<TorrentDetails, TorrentDTO>()
                .ForMember(dest => dest.CreatedAt,
                       opt => opt.MapFrom(src => src.CreatedAt.ToString("dd-MM-yyyy hh:mm:stt")))
                .ForMember(dest => dest.UpdatedAt,
                       opt => opt.MapFrom(src => src.UpdatedAt.ToString("dd-MM-yyyy hh:mm:sstt")));
        }
    }
}
