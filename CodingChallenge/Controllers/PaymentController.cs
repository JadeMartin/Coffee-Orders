using CodingChallenge.Models;
using System;


namespace CodingChallenge.controllers
{
    public class PaymentController
    {

//todo make async and enter into database
        public void post(Payment payment)
        {
            Console.WriteLine(payment.User);
        }
    }
}