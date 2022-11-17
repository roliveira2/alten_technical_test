using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltenTest.Entities
{
    public class GuestDTO
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime birth_date { get; set; }
        public string document_number { get; set; }
    }
}
