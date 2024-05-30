

namespace Hotel_Core_Layer.Specification
{
    public class RoomWithHoteAndFloorSpecification : BaseSpecification<Room>
    {
        public RoomWithHoteAndFloorSpecification()
        {
            Includes.Add(p => p.Floor); 
        }
        public RoomWithHoteAndFloorSpecification(int id) : base(p => p.Id == id)
        {
            Includes.Add(p => p.Floor);
        }
    }
}
