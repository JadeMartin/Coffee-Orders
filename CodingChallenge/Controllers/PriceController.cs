using CodingChallenge.Models;
using System;


namespace CodingChallenge.controllers
{
    public class PriceController
    {

//todo make async and enter into database
        public void post(Price price)
        {
            Console.WriteLine(price.Prices.Small);
        }
    }
}