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
        public void post(Payment payment)
        {
            paymentList.Add(payment);
        }

        public List<Payment> GetPayments()
        {
            return paymentList;
        }
    }
}