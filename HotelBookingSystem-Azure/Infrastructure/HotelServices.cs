using HotelBookingSystem_Azure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem_Azure.Infrastructure
{
    public class HotelServices : InterfaceHotelServices
    {
        public HBSDBContext HBSDBContext;

        public HotelServices(HBSDBContext hbsdbcontext)
        {
            this.HBSDBContext = hbsdbcontext;
        }

        public async Task<IList<Hotel>> HotelList()
        {
            return HBSDBContext.Set<Hotel>().ToList();
        }

        public async Task<IList<BookingRequest>> BookingRequestsList()
        {
            return HBSDBContext.Set<BookingRequest>().ToList();
        }

        public async Task<IList<BookingDetails>> Report()
        {
            return HBSDBContext.Set<BookingDetails>().ToList();
        }

        public async Task<IList<RoomDetails>> RoomList()
        {
            return HBSDBContext.Set<RoomDetails>().ToList();
        }

        public void AddHotel(Hotel hotel)
        {
            HBSDBContext.Add<Hotel>(hotel);
            HBSDBContext.SaveChanges();

        }

        void InterfaceHotelServices.UpdateHotel(Hotel hotel)
        {
            HBSDBContext.Update<Hotel>(hotel);
            HBSDBContext.SaveChanges();

        }

        public void DeleteHotel(int hotel_id)
        {
            Hotel hotel = GetHotel(hotel_id);
            if (hotel != null)
            {
                HBSDBContext.Remove<Hotel>(hotel);
                HBSDBContext.SaveChanges();
            }

        }
        private Hotel GetHotel(int hotel_id)
        {
            return HBSDBContext.Find<Hotel>(hotel_id);


        }

        public void RegisterNewUser(User user)
        {
            HBSDBContext.Add<User>(user);
            HBSDBContext.SaveChanges();

        }

        public void AddBookingRequest(BookingRequest booking)
        {
            HBSDBContext.Add<BookingRequest>(booking);
            HBSDBContext.SaveChanges();

        }

        public void ApproveBooking(BookingDetails booking)
        {
            HBSDBContext.Add<BookingDetails>(booking);
            HBSDBContext.SaveChanges();

        }


    }
}
