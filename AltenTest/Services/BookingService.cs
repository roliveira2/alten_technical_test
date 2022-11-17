using AltenTest.BLL;
using AltenTest.Entities;

using Dapper;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

using static AltenTest.Entities.BookingRequestBody;

namespace AltenTest.Services
{
    public interface IBookingService
    {
        RequestDTO Search(SearchReservation search_parameters);
        RequestDTO Add(RequestReservation booking_request);
        RequestDTO Update(UpdateReservation update_request);
    }
    public class BookingService : IBookingService
    {
        private readonly IBookingBLL _bll;

        public BookingService(IBookingBLL bll)
        {
            _bll = bll;
        }
        public RequestDTO Search(SearchReservation search_parameters)
        {
            try
            {
                RequestDTO validator = _bll.ValidSearch(search_parameters);
                if (validator.idErro == RequestDTO.ErrorEnum.ErrorValidating)
                {
                    return new RequestDTO()
                    {
                        idErro = RequestDTO.ErrorEnum.ErrorValidating,
                        listValidation = validator.listValidation
                    };
                }


                List<BookingResponseBody> bookings = new List<BookingResponseBody>();
                //using (var connection = new SqlConnection(""))
                //{
                //    bookings = new List<BookingResponseBody>(connection.Query<BookingResponseBody>("select * from bookings"));
                //}
                bookings = new BookingResponseBody().Mock();
                if (bookings.Any())
                {
                    return new RequestDTO()
                    {
                        idErro = RequestDTO.ErrorEnum.Success,
                        listObject = bookings
                    };
                }
                else
                {
                    return new RequestDTO()
                    {
                        idErro = RequestDTO.ErrorEnum.NoResult,
                    };

                }
            }
            catch (Exception ex)
            {
                return new RequestDTO()
                {
                    idErro = RequestDTO.ErrorEnum.ErrorRead,
                    txtErro = RequestDTO.ErrorCategory.ErrorRead + ex.Message
                }; ;
            }

        }

        public RequestDTO Add(RequestReservation booking_request)
        {
            try
            {
                RequestDTO validator = _bll.ValidNewBooking(booking_request);
                if (validator.idErro == RequestDTO.ErrorEnum.ErrorValidating)
                {
                    return new RequestDTO()
                    {
                        idErro = RequestDTO.ErrorEnum.ErrorValidating,
                        listValidation = validator.listValidation
                    };
                }

                //using (SQLContext db = new SQLContext())
                //{
                //    var _booking = new Booking();

                //    db.TB_BOOKING.Add(_booking);
                //    db.SaveChanges();

                return new RequestDTO()
                {
                    idErro = RequestDTO.ErrorEnum.Success,
                    identity = new BookingResponseBody().GenerateLocator(),
                    uniqueObject = new BookingResponseBody().Mock().FirstOrDefault()
                };
                //}
            }
            catch (Exception ex)
            {
                return new RequestDTO()
                {
                    idErro = RequestDTO.ErrorEnum.ErrorInsert,
                    txtErro = RequestDTO.ErrorCategory.ErrorInsert + ex.Message
                };
            }

        }

        public RequestDTO Update(UpdateReservation update_request)
        {
            try
            {
                RequestDTO validator = _bll.ValidUpdateBooking(update_request);
                if (validator.idErro == RequestDTO.ErrorEnum.ErrorValidating)
                {
                    return new RequestDTO()
                    {
                        idErro = RequestDTO.ErrorEnum.ErrorValidating,
                        listValidation = validator.listValidation
                    };
                }

                //CHECK IF THE BOOKING EXISTS WITH THE LASTNAME AND LOCATION INFORMED

                //using (SQLContext db = new SQLContext())
                //{
                //    var _booking = new Booking();

                //    db.TB_BOOKING.Add(_booking);
                //    db.SaveChanges();

                return new RequestDTO()
                {
                    idErro = RequestDTO.ErrorEnum.Success,
                    identity = new BookingResponseBody().GenerateLocator(),
                    uniqueObject = new BookingResponseBody().Mock().FirstOrDefault()
                };
                //}
            }
            catch (Exception ex)
            {
                return new RequestDTO()
                {
                    idErro = RequestDTO.ErrorEnum.ErrorInsert,
                    txtErro = RequestDTO.ErrorCategory.ErrorInsert + ex.Message
                };
            }

        }
    }
}
