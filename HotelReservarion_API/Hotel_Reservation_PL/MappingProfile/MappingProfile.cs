using AutoMapper;
using Hotel_Reservation_DAL.Models;
using Hotel_Reservation_PL.ViewModels;

namespace Hotel_Reservation_PL.MappingProfile
{
    public class MappingProfile_:Profile
    {
        public MappingProfile_()
        {
            CreateMap<Booking, BookViewModel>().ReverseMap()
    .ForMember(p => p.HotelBranch, p => p.MapFrom(p => p.Hotel))
    .ReverseMap();
            CreateMap<Room, RoomViewModel>()
            .ForMember(p => p.CountOfAdults, o => o.MapFrom(p => p.CountOfAdults))
            .ForMember(p => p.Status, p => p.MapFrom(p => p.Status ? "Reserved" : "Empty"))
            .ReverseMap();
        }
    }
}
