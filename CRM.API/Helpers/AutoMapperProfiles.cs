using System.Linq;
using AutoMapper;
using CRM.API.DTOs;
using CRM.API.DTOs.MessagesDto;
using CRM.API.Models;

namespace CRM.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UserForListDto>()
                .ForMember(dest => dest.PhotoURL, 
                           opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.DepartmentName,
                           opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.Age,
                           opt => opt.MapFrom(src => src.BirthDate.CalculateAge()));
            CreateMap<User,UserForDetailedDto>()
                .ForMember(dest => dest.PhotoURL, 
                           opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.DepartmentName,
                           opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.DepartmentPhone,
                           opt => opt.MapFrom(src => src.Department.Phone))
                .ForMember(dest => dest.Age,
                           opt => opt.MapFrom(src => src.BirthDate.CalculateAge()));

            CreateMap<UserForUpdateDto, User>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<Department,DepartmentForUserDto>();

            CreateMap<Customer, ClientForDetailedDto>();
            CreateMap<Customer,ClientForListDto>()
                .ForMember(dest => dest.OrdersCount,
                           opt => opt.MapFrom(src => src.Orders.Count));
            CreateMap<Order, OrderForClientDto>();

            CreateMap<Photo,PhotosForDetailedDto>();
            CreateMap<Photo,PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto,Photo>();

            CreateMap<Order, OrderForListDto>();
            CreateMap<Order, OrderForDetailedDto>()
                .ForMember(dest => dest.ExecutorName,
                           opt => opt.MapFrom(src => src.Executor.FullName));
            CreateMap<OrderForDetailedDto, Order>();
            CreateMap<OrderForUpdateDto, Order>();
            CreateMap<OrderForAddingDto, Order>();

            CreateMap<MessageForCreationDto, Message>().ReverseMap();
            CreateMap<Message, MessageToReturnDto>()
                .ForMember(dest => dest.SenderPhotoUrl,
                           opt => opt.MapFrom(u => u.Sender.Photos.FirstOrDefault(p => p.IsMain).Url))
                           
                .ForMember(dest => dest.RecipientPhotoUrl,
                           opt => opt.MapFrom(u => u.Recipient.Photos.FirstOrDefault(p => p.IsMain).Url));
        }
    }
}