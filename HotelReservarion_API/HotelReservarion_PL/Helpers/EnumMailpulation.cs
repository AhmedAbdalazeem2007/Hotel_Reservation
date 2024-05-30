using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelReservarion_PL.Helpers
{
    public static class EnumMailpulation<T> where T : Enum
    {
        public static List<SelectListItem> convettolist<T>()
        {
            var list = new List<SelectListItem>();
            list = Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(x => new SelectListItem
                {
                    Value = x.ToString(),
                    Text = x.ToString()
                }).ToList();
            return list;
        }
    }
}
