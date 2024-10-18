using System;
namespace std
{
    class Customer
    {
        public int customerId { set; get; }
        public string firstName { set; get; }
        public string lastName { set; get; }
        public string street { set; get; }
        public string city { set; get; }
        public string state { set; get; }
        public int Zipcode { set; get; }
        public string phone { set; get; }
        public string email { set; get; }
        public string password { set; get; }
    }
    class RetialCustomer
    {
        public string CreditCardType { set; get; }
        public string CreditCardNo { set; get; }

    }
    class CorporateCustomer
    {
        public string CompanyName { set; get; }
        public int freguentFlyerPts { set; get; }
        public string billingAccountNo { set; get; }
    }
    class Reservation
    {
        public int reservationNo { set; get; }
        public DateTime date { set; get; }
        public Customer customer { set; get; }
        public List<Seat> seats { set; get; }
    }
    class Flight
    {
        public int flightId { set; get; }
        public DateTime date { set; get; }
        public string origin { set; get; }
        public string destination { set; get; }
        public DateTime departureTime { set; get; }
        public DateTime arrivalTime { set; get; }
        public int seatingCapacity { set; get; }
        public List<Seat> seats { set; get; }
    }
    class Seat
    {
        public int seatNo { set; get; }
        public int rowNo { set; get; }
        public decimal price { set; get; }
        public string status { set; get; }
        public Flight flight { set; get; }
        public Reservation reservation { set; get; }
    }
}
 
