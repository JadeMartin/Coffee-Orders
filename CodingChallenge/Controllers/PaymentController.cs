using CodingChallenge.Models;
using System;
using System.Collections.Generic;


namespace CodingChallenge.controllers
{
    public class PaymentController
    {
        //TODO: Replace backend list with SQL lite DB
        private List<Payment> paymentList = new List<Payment>();

        //TODO make functions ASYNC & interact with database
        //POST: api/payment
        //[HttpPOST]
        //Post function to create and add payment to paymentList (Ideally eventually a database context)
        public void post(Payment payment)
        {
            paymentList.Add(payment);
        }

        //TODO make functions ASYNC & interact with database
        //GET: api/payment
        //[HttpGET]
        //Get function to return all payment in paymentList (Ideally eventually a database context)
        public List<Payment> GetPayments()
        {
            return paymentList;
        }
    }
}