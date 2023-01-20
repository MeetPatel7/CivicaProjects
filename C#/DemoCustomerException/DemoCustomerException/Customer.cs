using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCustomerException
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Phone { get; set; }
        public double CreditLimit {
            
            get { return CreditLimit; }
            
            set
            {
                if(value > 50000)
                {
                    throw new CustomerException("Entered value is more than 50000");
                }
                CreditLimit = value;
            }    
        }

        public Customer() 
        { }
        public Customer(int customerId, string customerName, string address, string city, int phone, double creditLimit)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            Address = address;
            City = city;
            Phone = phone;
            CreditLimit = creditLimit;
        }
    }
}
