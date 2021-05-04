using System;
using System.Collections.Generic;

namespace CleanCode.LongParameterList
{
    public class DateRange
    {
        public DateRange(DateTime dateFrom, DateTime dateTo)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
        }

        public DateTime DateFrom { get; }
        public DateTime DateTo { get; }
    }


    public class ReservationQuery
    {
        public ReservationQuery(DateRange dateRange, User user, int locationId, LocationType locationType,
            int? customerId = null)
        {
            DateRange = dateRange;
            User = user;
            LocationId = locationId;
            LocationType = locationType;
            CustomerId = customerId;
        }

        public DateRange DateRange { get; }
        public User User { get; }
        public int LocationId { get; }
        public LocationType LocationType { get; }
        public int? CustomerId { get; }
    }


    public class LongParameterList
    {
        public IEnumerable<Reservation> GetReservations(ReservationQuery query)
        {
            if (query.DateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (query.DateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> Reservations(ReservationQuery query)
        {
            if (query.DateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (query.DateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        private static Tuple<DateTime, DateTime> GetReservationDateRange(DateRange dateRange,
            ReservationDefinition reservationDefinition)
        {
            if (dateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        public void CreateReservation(DateRange dateRange, int locationId)
        {
            if (dateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }
    }

    internal class ReservationDefinition
    {
    }

    public class LocationType
    {
    }

    public class User
    {
        public object Id { get; set; }
    }

    public class Reservation
    {
    }
}