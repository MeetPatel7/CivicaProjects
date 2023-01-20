namespace Domain.Import
{
    public class Passenger
    {

        public string Name { get; private set; }
        public bool IsVIP { get; private set; }

        public Passenger(string name, bool vip)
        {
            Name = name;
            IsVIP = vip;
        }


    }

}
