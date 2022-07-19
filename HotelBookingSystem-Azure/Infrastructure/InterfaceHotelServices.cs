using HotelBookingSystem_Azure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem_Azure.Infrastructure
{
    public interface InterfaceHotelServices
    {
        Task<IList<Hotel>> HotelList();

        Task<IList<BookingRequest>> BookingRequestsList();

        Task<IList<BookingDetails>> Report();

        Task<IList<RoomDetails>> RoomList();

        void AddHotel(Hotel hotel);

        void UpdateHotel(Hotel hotel);

        void DeleteHotel(int hotel_id);

        void RegisterNewUser(User user);

        void AddBookingRequest(BookingRequest booking);

        void ApproveBooking(BookingDetails booking);

    }
}
