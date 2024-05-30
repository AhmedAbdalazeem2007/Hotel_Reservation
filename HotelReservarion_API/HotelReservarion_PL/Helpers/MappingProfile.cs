
namespace HotelReservarion_PL.Helpers
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			CreateMap<Room, RoomDto>()
				.ForMember(p => p.Status, o => o.MapFrom(p => p.Status ? "Free" : "Reserved"))
				.ForMember(p => p.Description, o => o.MapFrom(o => o.Description))
				.ForMember(p => p.Price, p => p.MapFrom(o => o.PricePerDay))
				.ForMember(p => p.HavePathroom, o => o.MapFrom(o => o.HavePathroom))
				.ForMember(p => p.FloorId, p => p.MapFrom(p => p.FloorId))
				.ForMember(p => p.TypeRoom, p => p.MapFrom(p => p.TypeRoom.ToString()))
				.ForMember(p => p.PictureUrl, o => o.MapFrom<RommPictureUrlSolver>())
				.ForMember(p => p.Floor, o => o.MapFrom(p => p.Floor.Description))
				.ReverseMap();
			CreateMap<Booking, ReservationBookDto>()
				.ForMember(p => p.CheckIn, o => o.MapFrom(p => p.CheckIn))
				.ForMember(p => p.TotalCost, p => p.MapFrom(p =>p.TotalCost))
				.ReverseMap();

			//CreateMap<Api_Core.Models.Identity.Address, AddressDto>().ReverseMap();
			//CreateMap<CustomerBasketDto, CustomerBasket>().ReverseMap();
			//CreateMap<BasketItemDto, BasketItem>().ReverseMap();
			//CreateMap<AddressDto, Api_Core.Models.Order_Aggregate.Address>().ReverseMap();


		}
	}
}
