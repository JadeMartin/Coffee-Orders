// using CodingChallenge.Models;
// using Newtonsoft.Json;
// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.string;
// using Xunit;

// namespace CodingChallenge.Tests
// {

//     public class Tests
//     {

//         // Example Prices JSON test data that may be used
//         //  prices_json =[ 
//         //                 { 'drink_name': 'short espresso', 'prices': { 'small': 3.03 } },
//         //                 { 'drink_name': 'latte', 'prices': { 'small': 3.50, 'medium': 4.00, 'large': 4.50 } },
//         //                 { 'drink_name': 'flat white', 'prices': { 'small': 3.50, 'medium': 4.00, 'large': 4.50 } },
//         //                 { 'drink_name': 'long black', 'prices': { 'small': 3.25, 'medium': 3.50 } },
//         //                 { 'drink_name': 'mocha', 'prices': { 'small': 4.00, 'medium': 4.50, 'large': 5.00 } },
//         //                 { 'drink_name': 'supermochacrapucaramelcream', 'prices': { 'large': 5.00, 'huge': 5.50, 'mega': 6.00, 'ultra': 7.00 } }
//         //               ]    
                            

//         //Example Orders JSON test data 
//         // orders_json = [ 
//         //                 { 'user': 'coach', 'drink': 'long black', 'size': 'medium' },
//         //                 { 'user': 'ellis', 'drink': 'long black', 'size': 'small' },
//         //                 { 'user': 'rochelle', 'drink': 'flat white', 'size': 'large' },
//         //                 { 'user': 'coach', 'drink': 'flat white', 'size': 'large' },
//         //                 { 'user': 'zoey', 'drink': 'long black', 'size': 'medium' },
//         //                 { 'user': 'zoey', 'drink': 'short espresso', 'size': 'small' }
//         //               ]
                

//         //Example Payments JSON test data
//         // payments_json = [
//         //                     { 'user': 'coach', 'amount': 2.50 },
//         //                     { 'user': 'ellis', 'amount': 2.60 },
//         //                     { 'user': 'rochelle', 'amount': 4.50 },
//         //                     { 'user': 'ellis', 'amount': 0.65 }
//         //                 ] 

//         [Fact]
//         public void OutputJSONInExpectedForm()
//         {
//             // Based on test data above the expected result would be 
//             // { "user": "coach","order_total": 8.00, "payment_total": 2.50, "balance": 5.50 },
//             // { "user": "ellis","order_total": 3.25, "payment_total": 3.25, "balance": 0.00 },
//             // { "user": "rochelle", "order_total": 4.50, "payment_total": 4.50, "balance": 0.00 },
//             // { "user": "zoey","order_total": 6.53, "payment_total": 0.00, "balance": 6.53 }
//             throw new NotImplementedException("Output JSON in expected form.");
//         }

//         [Fact]
//         public void HasUsersWhoOrderedCoffee()
//         {
//             // Assert result[0].user == "coach"
//             // Assert result[1].user == "ellis"
//             // Assert result[2].user == "rochelle"
//             // Assert result[3].user == "zoey"
//             throw new NotImplementedException("Has a bunch of users who ordered coffee");
//         }

//         [Fact]
//         public void HasOrderTotalsForUsers()
//         {
//             // Assert result[0].order_total == 8.00
//             // Assert result[1].order_total == 3.25
//             // Assert result[2].order_total == 4.50
//             // Assert result[3].order_total == 6.53
//             throw new NotImplementedException("Has order totals for each user");
//         }

//         [Fact]
//         public void HasPaymentTotalsForUsers()
//         {
//             // Assert result[0].payment_total == 2.50
//             // Assert result[1].payment_total == 3.25
//             // Assert result[2].payment_total == 4.50
//             // Assert result[3].payment_total == 0.00
//             throw new NotImplementedException("Has payment totals for each user");
//         }

//         [Fact]
//         public void HasCurrentBalanceForUsers()
//         {
//             // Assert result[0].balance == 5.50
//             // Assert result[1].balance == 0.00
//             // Assert result[2].balance == 0.00
//             // Assert result[3].balance == 6.53
//             throw new NotImplementedException("Has current balance for each user");
//         }
//     }
// }
