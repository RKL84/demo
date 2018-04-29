### Live Demo _(Microsoft Azure)_ ###

* **Acme.RemoteFlights.Api** <sup>_(ASP.NET Core Web API, Entity Framework Core,.NET Standard)</sup>_  
  [http://acmeremoteflightsapi20180429.azurewebsites.net/api/flights](http://acmeremoteflightsapi20180429.azurewebsites.net/api/flights)
  
  #### Running & Debugging Acme.RemoteFlights.Api Locally ####
* Clone this repo: https://github.com/RKL84/demo.git 
* Acme.RemoteFlights.Api *<sup>(ASP.NET Core Web API)</sup>*
  * Restore *([Acme.RemoteFlights.Api.bacpac](https://github.com/RKL84/demo/blob/master/Acme.RemoteFlights.Database/Sql))* Acme.RemoteFlights SQL Database
  * Install lastest .NET Core SDK **after** Visual Studio 2017 installed
  * Open Acme.RemoteFlights.sln Solution in Visual Studio 2017
  * Set Acme.RemoteFlights.Api as Startup Project for the Solution
  * Verify SQL connection string in [appsettings.json](https://github.com/RKL84/demo/blob/master/Acme.RemoteFlights.Api/appsettings.Development.json#L16) is correct, respective to local environment
  * F5 to launch Acme.RemoteFlights.Api in debug mode in Visual Studio. 
  
  The web application is configured to run using port 57108.
  Sample JSON requests for the following scenarios are provided below -  
  
   **List all flights: Flight no, start time, end time, passenger capacity, departer city, arrival city** 
  
  http://localhost:57108/api/flights/?flightNo=AIR-LA-NY&departureCity=Los%20Angeles&arrivalCity=New%20York&passengerCapacity=10&departureTime=2015-03-28&arrivalTime=2015-03-29
 
  **Search for bookings:  by passenger name, date, arrival city, departure city, flight number** 
   
  http://localhost:57108/api/bookings/?passengerName=John&flightNo=AIR-LA-NY&arrivalCity=New%20York&departureCity=Los%20Angeles&travelDate=2015-03-28
  
  **Check availability : by giving start and end Date. No of passengers** 
  
  http://localhost:57108/api/bookings/availibility/?startDate=2015-03-28&endDate=2015-03-29&numberOfPassengers=1
 
  **Make booking: by selecting flights and providing passenger details** 
  
  http://localhost:57108/api/bookings?scheduleId=10&userName=Richard&age=25&email=richard@test.com




