using HotelBookingSystem_Azure.Infrastructure;
using HotelBookingSystem_Azure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem_Azure.Controllers
{
    public class AdminController : Controller
    {
        private readonly InterfaceHotelServices HotelServices;
        private readonly ILogger<AdminController>  _logger;
        private readonly SendServiceBusMessage _sendServiceBusMessage;

        public AdminController(InterfaceHotelServices HotelServices, ILogger<AdminController> logger , SendServiceBusMessage sendServiceBusMessage)
        {
            _logger = logger;
            _logger.LogInformation("HBS SYSTEM APP");
            this.HotelServices = HotelServices;
            _sendServiceBusMessage = sendServiceBusMessage;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
        public async Task<IActionResult> HotelList()
        {
            _logger.LogInformation("HotelList endpoint starts");
            var Hotel = await HotelServices.HotelList();
            try
            {
                if (Hotel == null) return NotFound();
                _logger.LogInformation("HotelList endpoint completed");
            }
            catch (Exception ex)
            {
                _logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest();
            }
            return View(Hotel);
        }

        public async Task<IActionResult> BookingRequestList()
        {
            _logger.LogInformation("Booking request list endpoint starts");
            var Request = await HotelServices.BookingRequestsList();
            try
            {
                if (Request == null) return NotFound();
                _logger.LogInformation("Booking request list endpoint  completed");
            }
            catch (Exception ex)
            {
                _logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest();
            }
            return View(Request);
        }

        public async Task<IActionResult> Report()
        {
            _logger.LogInformation("Report endpoint starts");
            var report = await HotelServices.Report();
            try
            {
                if (report == null) return NotFound();
                _logger.LogInformation("Report endpoint completed");
            }
            catch (Exception ex)
            {
                _logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest();
            }
            return View(report);
        }

        public IActionResult AddHotel()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> AddHotel(Hotel hotel)
        {
            try
            {
                HotelServices.AddHotel(hotel);

            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            ViewBag.Message = string.Format("Hotel Added Successfully");
            return View();

        }
       

        public IActionResult UpdateHotel()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateHotel(Hotel hotel)
        {
            try
            {
                HotelServices.UpdateHotel(hotel);


            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            ViewBag.Message = string.Format("updated hotel data Successfully");
            return View();

        }


    
        public IActionResult DeleteHotel()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteHotel(int hotel_id)
        {
            try
            {
                HotelServices.DeleteHotel(hotel_id);

            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            ViewBag.Message = string.Format("Hotel Deleted Successfully");
            return View();
        }

        public IActionResult ApproveBooking()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ApproveBooking(BookingDetails booking)
        {
            try
            {
                HotelServices.ApproveBooking(booking);

                await _sendServiceBusMessage.sendServiceBusMessage(new ServiceBusMessageData
                {
                    booking_id = booking.booking_id,
                    room_id = booking.room_id,
                    user_id = booking.user_id,
                    Action = "Approved Booking"
                });

            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            ViewBag.Message = string.Format("Booking Approved  Successfully");
            return View();

        }



    }
}
