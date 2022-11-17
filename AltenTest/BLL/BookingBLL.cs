using AltenTest.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static AltenTest.Entities.BookingRequestBody;

namespace AltenTest.BLL
{
    public interface IBookingBLL
    {
        RequestDTO ValidSearch(SearchReservation search_parameters);
        RequestDTO ValidNewBooking(RequestReservation request_booking);
        RequestDTO ValidUpdateBooking(UpdateReservation update_booking);
    }
    public class BookingBLL : IBookingBLL
    {
        public RequestDTO ValidSearch(SearchReservation search_parameters)
        {
            if (search_parameters.date_end < search_parameters.date_start)
            {
                return new RequestDTO()
                {
                    idErro = RequestDTO.ErrorEnum.ErrorValidating,
                    listValidation = new List<string>() { "Date end has to be greather or equal to date start." }
                };
            }
            else
            {
                return new RequestDTO()
                {
                    idErro = RequestDTO.ErrorEnum.Success
                };
            }
        }

        public RequestDTO ValidNewBooking(RequestReservation request_booking)
        {
            if (request_booking.date_end < request_booking.date_start)
            {
                return new RequestDTO()
                {
                    idErro = RequestDTO.ErrorEnum.ErrorValidating,
                    listValidation = new List<string>() { "Date end has to be greather or equal to date start." }
                };
            }
            else if (request_booking.date_end.Date == DateTime.Now.Date)
            {
                return new RequestDTO()
                {
                    idErro = RequestDTO.ErrorEnum.ErrorValidating,
                    listValidation = new List<string>() { "All reservations start at least the next day of booking" }
                };
            }
            else if ((request_booking.date_end.Date - DateTime.Now.Date).TotalDays > 30)
            {
                return new RequestDTO()
                {
                    idErro = RequestDTO.ErrorEnum.ErrorValidating,
                    listValidation = new List<string>() { "A new booking can’t be reserved more than 30 days in advance" }
                };
            }
            else if ((request_booking.date_end.Date - request_booking.date_start.Date).TotalDays > 4)
            {
                return new RequestDTO()
                {
                    idErro = RequestDTO.ErrorEnum.ErrorValidating,
                    listValidation = new List<string>() { "the stay can’t be longer than 3 days." }
                };
            }
            else
            {
                return new RequestDTO()
                {
                    idErro = RequestDTO.ErrorEnum.Success
                };
            }
        }

        public RequestDTO ValidUpdateBooking(UpdateReservation update_booking)
        {
            if (update_booking.date_end < update_booking.date_start)
            {
                return new RequestDTO()
                {
                    idErro = RequestDTO.ErrorEnum.ErrorValidating,
                    listValidation = new List<string>() { "Date end has to be greather or equal to date start." }
                };
            }
            else if (update_booking.date_end.Date == DateTime.Now.Date)
            {
                return new RequestDTO()
                {
                    idErro = RequestDTO.ErrorEnum.ErrorValidating,
                    listValidation = new List<string>() { "All reservations start at least the next day of booking" }
                };
            }
            else if ((update_booking.date_end.Date - DateTime.Now.Date).TotalDays > 30)
            {
                return new RequestDTO()
                {
                    idErro = RequestDTO.ErrorEnum.ErrorValidating,
                    listValidation = new List<string>() { "A new booking can’t be reserved more than 30 days in advance" }
                };
            }
            else if ((update_booking.date_end.Date - update_booking.date_start.Date).TotalDays > 4)
            {
                return new RequestDTO()
                {
                    idErro = RequestDTO.ErrorEnum.ErrorValidating,
                    listValidation = new List<string>() { "the stay can’t be longer than 3 days." }
                };
            }
            else
            {
                return new RequestDTO()
                {
                    idErro = RequestDTO.ErrorEnum.Success
                };
            }
        }
    }
}
