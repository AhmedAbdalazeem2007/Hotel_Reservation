﻿

namespace Hotel_Reservation_DAL.Models
{
    public class BaseEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
