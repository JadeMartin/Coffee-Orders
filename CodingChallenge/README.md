# Mudbath Mocha

Make sure you read **all** of this document carefully, and follow the guidelines
in it. Pay particular attention to the "What We Care About" section. We also
recommend you read
[9 Essential Tips on How to Tackle a Coding Challenge](https://www.codementor.io/learn-programming/9-essential-tips-tackle-coding-challenge).

## Background

We like coffee.

So we built an app to fetch coffee for people from our favourite barista.

The app keeps track of coffee ordered; what the balance is for each user; what users have paid for already; and what is still owed.

## Data

We've got the following data

- `Data/prices.json` - provided by our barista. Has details of what beverages are available, and what their prices are.
- `Data/orders.json` - list of beverages ordered by users of the app.
- `Data/payments.json` - list of payments made by users paying for items they have purchased.

## Requirements

- Load the list of prices
- Load the orders
  - Calculate the total cost of each user's orders
- Load the payments
  - Calculate the total payment for each user
  - Calculate what each user now owes
- Return a JSON string containing the results of this work.

## Getting Started

Mudbath Mocha requires .NET Core 2.1 to be installed. However feel free to utilise a newer version of .NET Core if you see fit.

## Submitting The Test

1. Ensure that everything you wish to submit is committed to the `master` branch
1. Zip your solution (please exclude any build artifacts or any other unnecessary files such as bin/obj)
1. Email the zip from above to: david.boyd@mudbath.com.au

## What We Care About

First, you should write in C#/.NET, even if you're not strong in it. We don't mind if your code isn't perfect. If you're *really* not comfortable in C#/.NET, talk to us, and we'll consider letting you use another language.

We're interested in your method and how you approach the problem just as much as we're interested in the end result. We'll go through your code with you afterwards, and you can talk to us about how you tackled it, why you chose the approach you did, _etcetera_. We don't particularly mind which version of .NET you use however we would prefer a flavour of .NET Core.

That said, here's what you should aim for with your code:

- Clean, readable, production quality code; would we want to work with your code as part of a bigger codebase?
- Good object modelling and design decisions. We are looking for an object-oriented solution, even if you think procedural code would make more sense for this problem.
- Extensible code; adding features will be another exercise when you come back in person.
- Good use of C# idioms.
- Solid testing approach _(hint - you should write more unit tests than what has been provided)_
- Use Git (a private repo please)!
 - Commit small changes often so we can see your approach, and progress.

We haven't hidden any nasty tricks in the test. Don't overthink it. Just write nice, solid code.
