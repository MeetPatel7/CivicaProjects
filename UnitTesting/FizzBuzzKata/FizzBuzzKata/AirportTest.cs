using Domain.Aeronautics.Before;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzKata
{
    public class AirportTest
    {
        [Fact]
        public void business_flight_vip_passenger_add_allow()
        {
            Passenger john = new Passenger("John", vip: true);

            Flight businessFlight = new Flight(2, flightType: "Business");

            bool ActualResult = businessFlight.AddPassenger(john);
            Assert.Equal(true, ActualResult);

        }

        [Fact]
        public void business_flight_usual_passenger_add_not_allow()
        {
            Passenger mike = new Passenger("Mike", vip: false);

            Flight businessFlight = new Flight(2, flightType: "Business");

            //act
            bool ActualResult = businessFlight.AddPassenger(mike);

            //assert
            Assert.Equal(false, ActualResult);
        }

        [Fact]
        public void add_flightType_Economy_PassengerType_usual_returnTrue()
        {
            Passenger mike = new Passenger("Mike", vip: true);

            Flight economyFlight = new Flight(2, flightType: "Economy");

            //act
            bool ActualResult = economyFlight.AddPassenger(mike);

            //assert
            Assert.Equal(true, ActualResult);
        }

        [Fact]
        public void add_flightType_outOfRangeExcetion()
        {
            Passenger mike = new Passenger("Mike", vip: false);

            Flight localFlight = new Flight(2, flightType: "Local");

            //act
            Exception ex  = Record.Exception(() => localFlight.AddPassenger(mike));

            //assert
            Assert.IsType<ArgumentOutOfRangeException>(ex);
        }

        [Fact]
        public void economy_flight_usual_passenger_remove_allow()
        {
            Passenger nike = new Passenger("Nike", vip: false);

            Flight economyFlight = new Flight(3, flightType: "Economy");

            economyFlight.AddPassenger(nike);

            bool ActualResult = economyFlight.RemovePassenger(nike);

            Assert.Equal(true, ActualResult);
        }

        [Fact]
        public void economy_flight_vip_passenger_remove_not_allow()
        {
            Passenger nike = new Passenger("Nike", vip: true);

            Flight economyFlight = new Flight(3, flightType: "Economy");

            bool ActualResult = economyFlight.RemovePassenger(nike);

            Assert.Equal(false, ActualResult);
        }

        [Fact]
        public void business_flightTyep_return_false()
        {
            Passenger mike = new Passenger("Mike", vip: true);

            Flight businessFlight = new Flight(2, flightType: "Business");

            //act
            bool ActualResult = businessFlight.RemovePassenger(mike);

            //assert
            Assert.Equal(false, ActualResult);
        }

        [Fact]
        public void remove_flightType_outOfRangeExcetion()
        {
            Passenger mike = new Passenger("Mike", vip: false);

            Flight localFlight = new Flight(2, flightType: "Local");

            //act
            Exception ex = Record.Exception(() => localFlight.RemovePassenger(mike));

            //assert
            Assert.IsType<ArgumentOutOfRangeException>(ex);
        }
    }
}