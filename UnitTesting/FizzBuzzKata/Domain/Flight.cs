namespace Domain.Aeronautics.Before
{
    public class Flight
    {
        public int Id { get; private set; }

		private List<Passenger> _passengersList = new List<Passenger>();

        public string FlightType { get; private set; }

        public Flight(int id, string flightType)
		{
			Id = id;
            FlightType = flightType;    
		}

		public IEnumerable<Passenger> GetPassengers()
        {
			return _passengersList;
        }
		public bool AddPassenger(Passenger passenger)
		{
			switch (FlightType.ToLower())
			{
				case "economy":
					{
						_passengersList.Add(passenger);
						return true;
					}

				case "business":
					if (passenger.IsVIP)
					{
						 _passengersList.Add(passenger);
						return true;
					}
					return false;

				default:
					throw new ArgumentOutOfRangeException("Unknown type: " + FlightType);
			}

		}

		public bool RemovePassenger(Passenger passenger)
		{
			switch (FlightType.ToLower())
			{
				case "economy":
					if (passenger.IsVIP == false)
					{
						return _passengersList.Remove(passenger);
					}
					return false;

				case "business":
					return false;

				default:
					throw new ArgumentOutOfRangeException("Unknown type: " + FlightType);
			}
		}

	}
}
