using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltenTest.Entities
{
    public class BookingRequestBody
    {
        public class RequestReservation
        {
            public DateTime date_start { get; set; }
            public DateTime date_end { get; set; }
            public List<GuestDTO> guests { get; set; }
        }

        public class UpdateReservation
        {
            public DateTime date_start { get; set; }
            public DateTime date_end { get; set; }
            public List<GuestDTO> guests { get; set; }
            public string locator { get; set; }
            public bool to_cancel { get; set; }
        }

        public class SearchReservation
        {
            public DateTime date_start { get; set; }
            public DateTime date_end { get; set; }
            public string locator { get; set; }
        }
    }
}
