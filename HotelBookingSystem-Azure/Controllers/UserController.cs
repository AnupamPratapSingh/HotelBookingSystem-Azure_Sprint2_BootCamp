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
    public class UserController : Controller
    {
        private readonly InterfaceHotelServices HotelServices;
        private readonly ILogger<UserController> _logger;
        private readonly SendServiceBusMessage _sendServiceBusMessage;

        public UserController(InterfaceHotelServices HotelServices, ILogger<UserController> logger , SendServiceBusMessage sendServiceBusMessage)
        {
            _logger = logger;
            _logger.LogInformation("HBS SYSTEM APP");
            this.HotelServices = HotelServices;
            _sendServiceBusMessage = sendServiceBusMessage;
        }
        public IActionResult User()
        {
            return View();
        }

        public IActionResult RegisterNewUser()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> RegisterNewUser(User user)
        {
            try
            {
                HotelServices.RegisterNewUser(user);

                await _sendServiceBusMessage.sendServiceBusMessage(new ServiceBusMessageData
                {
                    user_name = user.user_name,
                    user_id = user.user_id,
                    Action = "Registered"
                });

            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            ViewBag.Message = string.Format("User Added Successfully");
            return View();

        }

        public IActionResult AddBookingRequest()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddBookingRequest(BookingRequest booking)
        {
            try
            {
                HotelServices.AddBookingRequest(booking);

                await _sendServiceBusMessage.sendServiceBusMessage(new ServiceBusMessageData
                {
                    user_name = booking.user_name,
                    Booking_id = booking.Booking_id,
                    hotel_name = booking.hotel_name,
                    Action = "Requested For Booking"
                });

            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            ViewBag.Message = string.Format("Booking Request Has Been Made Successfully");
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
        public async Task<IActionResult> RoomList()
        {
            _logger.LogInformation("Room list endpoint starts");
            var Room = await HotelServices.RoomList();
            try
            {
                if (Room == null) return NotFound();
                _logger.LogInformation("Roomlist endpoint completed");
            }
            catch (Exception ex)
            {
                _logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest();
            }
            return View(Room);
        }



    }
}
