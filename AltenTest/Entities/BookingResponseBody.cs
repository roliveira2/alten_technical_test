using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltenTest.Entities
{
    public class BookingResponseBody
    {
        public DateTime date_start { get; set; }
        public DateTime date_end { get; set; }
        public string locator { get; set; }
        public List<GuestDTO> guests { get; set; }


        public List<BookingResponseBody> Mock()
        {
            List<BookingResponseBody> mock_temp = new List<BookingResponseBody>();
            mock_temp.Add(new BookingResponseBody()
            {
                date_start = new DateTime(2022, 11, 15),
                date_end = new DateTime(2022, 11, 17),
                locator = GenerateLocator(),
                guests = new List<GuestDTO>()
                {
                    new GuestDTO()
                    {
                        first_name ="Jhon",
                        last_name = "Doe",
                        birth_date = new DateTime(1985,07,5)
                    },
                    new GuestDTO()
                    {
                        first_name ="Maria",
                        last_name = "Cruz",
                        birth_date = new DateTime(1989,08,25)
                    },
                }
            });
            return mock_temp;
        }

        private static Random random = new Random();
        public string GenerateLocator()
        {

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
