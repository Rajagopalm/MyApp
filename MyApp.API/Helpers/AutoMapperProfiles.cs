using System.Linq;
using AutoMapper;
using MyApp.API.Dtos;
using MyApp.API.Models;

namespace MyApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt =>
                {
                    opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                });
            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt =>
                {
                    opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                });
            CreateMap<Photo, PhotosForDetailedDto>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto, Photo>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<MessageForCreationDto, Message>().ReverseMap();
            CreateMap<Message, MessageToReturnDto>()
                .ForMember(m => m.SenderPhotoUrl, opt => opt
                    .MapFrom(u => u.Sender.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(m => m.RecipientPhotoUrl, opt => opt
                    .MapFrom(u => u.Recipient.Photos.FirstOrDefault(p => p.IsMain).Url));
            CreateMap<Student, StudentForListDto>();
            CreateMap<Student, StudentForDetailedDto>()
                .ForMember(dest => dest.CurrentCity,
                    opts => opts.MapFrom(src => src.CurrentCityNavigation.Name))
                .ForMember(dest => dest.CurrentDistrict,
                    opts => opts.MapFrom(src => src.CurrentDistrictNavigation.Name));
            CreateMap<StudentEnrollment, StudentEnrollmentsForDetailedDto>()
                .ForMember(dest => dest.CollegeName,
                    opts => opts.MapFrom(
                        src => src.College.Name
                    )).ReverseMap();
            CreateMap<StudentForUpdateDto, Student>();
            CreateMap<SubDistrict, SubDistrictsForListDto>();
            CreateMap<District, DistrictsForListDto>();
        }
    }
}