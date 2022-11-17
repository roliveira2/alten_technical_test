using AltenTest.Entities;
using AltenTest.Services;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Net.Mime;

using static AltenTest.Entities.BookingRequestBody;

namespace AltenTest.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/booking/")]
    public class BookingController : Controller
    {
        private readonly IBookingService _service;

        public BookingController(IBookingService service)
        {
            _service = service;
        }

        /// <summary>
        /// Returns a list or a single booking
        /// </summary>
        /// <response code="200">A booking was found</response>
        /// <response code="204">No bookings were found with the search parameters entered</response>
        /// <response code="400">The data sent is incorrect.</response>
        /// <response code="401">If the operation is not authorized.</response>
        /// <response code="500">An error occurred while looking for the booking.</response>
        [HttpPost("search")]
        [ProducesResponseType(200, Type = typeof(BookingResponseBody))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500, Type = typeof(string))]
        public IActionResult Search([FromBody] SearchReservation search_parameters)
        {
            try
            {
                RequestDTO retorno = _service.Search(search_parameters);

                #region Return      
                if (retorno.idErro == RequestDTO.ErrorEnum.ErrorValidating)
                    return StatusCode(400, retorno.listValidation);
                else if (retorno.idErro == RequestDTO.ErrorEnum.Success)
                    return Ok(retorno.listObject);
                else
                    return NotFound(RequestDTO.ErrorEnum.NoResult);
                #endregion
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Create a new booking
        /// </summary>
        /// <response code="200">The booking was created successfully</response>
        /// <response code="400">The data sent is incorrect.</response>
        /// <response code="401">If the operation is not authorized.</response>
        /// <response code="500">An error occurred while looking for the booking.</response>
        [HttpPost("")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500, Type = typeof(string))]
        public IActionResult Post([FromBody] RequestReservation booking_request, int? site_id = null)
        {
            try
            {
                RequestDTO retorno = _service.Add(booking_request);

                #region Return      
                if (retorno.idErro == RequestDTO.ErrorEnum.ErrorValidating)
                    return StatusCode(400, retorno.listValidation);
                else if (retorno.idErro == RequestDTO.ErrorEnum.Success)
                    return Ok(retorno.uniqueObject);
                else
                    return BadRequest(retorno.txtErro);
                #endregion
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update a booking
        /// </summary>
        /// <response code="200">The booking was updated successfully</response>
        /// <response code="400">The data sent is incorrect.</response>
        /// <response code="401">If the operation is not authorized.</response>
        /// <response code="500">An error occurred while looking for the booking.</response>
        [HttpPut("")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500, Type = typeof(string))]
        public IActionResult Post([FromBody] UpdateReservation update_request, int? site_id = null)
        {
            try
            {
                RequestDTO retorno = _service.Update(update_request);

                #region Return      
                if (retorno.idErro == RequestDTO.ErrorEnum.ErrorValidating)
                    return StatusCode(400, retorno.listValidation);
                else if (retorno.idErro == RequestDTO.ErrorEnum.Success)
                    return Ok(retorno.uniqueObject);
                else
                    return BadRequest(retorno.txtErro);
                #endregion
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
