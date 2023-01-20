namespace Domain.Import
{
    public abstract class Flight
    {
        public int Id { get; private set; }

        public List<Passenger> passengersList = new List<Passenger>();

        public string FlightType { get; private set; }

        protected Flight(int id)
        {
            Id = id;
        }

        public IEnumerable<Passenger> GetPassengers()
        {
            return passengersList;
        }
        public abstract bool AddPassenger(Passenger passenger);
        //{
        //    switch (FlightType.ToLower())
        //    {
        //        case "economy":
        //            {
        //                passengersList.Add(passenger);
        //                return true;
        //            }

        //        case "business":
        //            if (passenger.IsVIP)
        //            {
        //                passengersList.Add(passenger);
        //                return true;
        //            }
        //            return false;

        //        default:
        //            throw new ArgumentOutOfRangeException("Unknown type: " + FlightType);
        //    }

        //}

        public abstract bool RemovePassenger(Passenger passenger);
        //{
        //    switch (FlightType.ToLower())
        //    {
        //        case "economy":
        //            if (passenger.IsVIP == false)
        //            {
        //                return _passengersList.Remove(passenger);
        //            }
        //            return false;

        //        case "business":
        //            return false;

        //        default:
        //            throw new ArgumentOutOfRangeException("Unknown type: " + FlightType);
        //    }
        //}

    }
}
